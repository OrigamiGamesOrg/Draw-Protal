using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PathCreator : MonoBehaviour
{
    /*public LayerMask floorMask;
    public GameObject hintUI;

    private LineRenderer lineRenderer;
    private Camera cam;

    private List<Vector3> points = new List<Vector3>();

    public Action<IEnumerable<Vector3>> OnNewPathCreated;

    public Vector3 startTouch;
    public Vector3 endTouch;

    public Vector3 endNormal , startNormal = Vector3.zero;

    private bool startCheck = false;

    public float minDistance = 5f;
   // public Vector3 targetPos;*/

    private LineRenderer lineRenderer;
    private Camera mainCam;
    private MouseManager mouseManager;

    public LayerMask wallMask, floorMask;
    public float minLine;

    public GameObject portal1, portal2;

    private List<Vector3> points = new List<Vector3>();
    private Vector3 startPos, endPos;

    private GameObject player;
    RaycastHit hit;
    void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        mouseManager = GetComponent<MouseManager>();
        player = GameObject.FindGameObjectWithTag("Player");
        mainCam = Camera.main;
    }

    private void Start()
    {
        lineRenderer.enabled = false;
        //Invoke("ActivateHint", 2f);
    }

    void Update()
    {
        if (!GameManager.instance.isPlaying || !player.activeSelf)
        {
            return;
        }

        else if (Input.GetMouseButtonDown(0))
        {
            lineRenderer.enabled = false;
            points.Clear();
            Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);


            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (hit.collider.CompareTag("Door"))
                {
                    StartCoroutine(SendPlayerToPos(hit.point));
                    lineRenderer.enabled = false;
                    return;
                }

                if (hit.collider.CompareTag("Server"))
                {
                    lineRenderer.enabled = false;
                    return;
                }
            }

            if (!Physics.Raycast(ray, out hit, Mathf.Infinity, wallMask))
            {
                if (Physics.Raycast(ray, out hit, Mathf.Infinity, floorMask))
                {
                    StartCoroutine(SendPlayerToPos(hit.point));
                    return;
                }
                lineRenderer.enabled = false;
                return;
            }
            else
            {
                if (portal1.GetComponent<TelePort>().portalIsOpen || portal2.GetComponent<TelePort>().portalIsOpen)
                {
                    lineRenderer.enabled = false;
                    return;
                }
                lineRenderer.enabled = true;
                portal1.SetActive(false);
                portal2.SetActive(false);
                portal1.transform.rotation = Quaternion.LookRotation(hit.normal);
                portal1.transform.localEulerAngles = new Vector3(0, portal1.transform.localEulerAngles.y, 0);
            }
        }

        else if (Input.GetMouseButton(0))
        {
            Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (DistanceToLastPoint(hit.point) > 1f)
                {
                    points.Add(hit.point);
                    lineRenderer.positionCount = points.Count;
                    lineRenderer.SetPositions(points.ToArray());
                }
            }
        }

        else if (Input.GetMouseButtonUp(0))
        {
            if (!lineRenderer.enabled)
            {

            }
            else
            {
                Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                {
                    if (hit.collider.CompareTag("Door"))
                    {
                        lineRenderer.enabled = false;
                        return;
                    }

                    if (hit.collider.CompareTag("Server"))
                    {
                        lineRenderer.enabled = false;
                        return;
                    }
                }

                if (Physics.Raycast(ray, out hit, Mathf.Infinity, wallMask))
                {
                    if (Vector3.Distance(points.First(), points.Last()) > minLine)
                    {
                        startPos = points.First();
                        endPos = points.Last();

                        portal1.SetActive(true);
                        portal2.SetActive(true);

                        startPos.y = portal1.transform.position.y;
                        endPos.y = portal2.transform.position.y;

                        portal1.transform.position = startPos;
                        portal2.transform.position = endPos;

                        portal2.transform.rotation = Quaternion.LookRotation(hit.normal);
                        portal2.transform.localEulerAngles = new Vector3(0, portal2.transform.localEulerAngles.y, 0);

                        Invoke("SendPlayerToPortal", 0.1f);


                        /*if(Vector3.Distance(transform.position,portal2.transform.position) < 
                        Vector3.Distance(transform.position,portal1.transform.position))
                        {
                            mouseManager.GetSendPos(portal2.transform.position);
                        }
                        else
                        {
                            mouseManager.GetSendPos(portal1.transform.position);
                        }*/

                        Debug.Log("Create Portal");
                    }
                    else
                    {
                        StartCoroutine(SendPlayerToPos(hit.point));
                        Debug.Log("Move");
                    }
                }
            }

            lineRenderer.enabled = false;
            points.Clear();
        }

        /*if (MenuManager.Instance.CurrentMenu == MenuManager.Instance.m_Hud && !MenuManager.isLevelComplete)
        {
            if (Input.GetMouseButtonDown(0))
            {
                startTouch = Vector3.zero;
                endTouch = Vector3.zero;
                hintUI.SetActive(false);
                points.Clear();
                lineRenderer.enabled = true;
                RaycastHit hit;
                if(Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hit,Mathf.Infinity,floorMask))
                {
                    startNormal = hit.normal;
                }
            }

            if (Input.GetMouseButton(0))
            {
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, Mathf.Infinity, floorMask))
                {
                    endNormal = hit.normal;
                    startCheck = true;
                    if (DistanceToLastPoint(hit.point) > 1f)
                    {
                        points.Add(hit.point + hit.normal.normalized * 1.8f);
                        lineRenderer.positionCount = points.Count;
                        lineRenderer.SetPositions(points.ToArray());
                    }
                }
            }
            else if (Input.GetMouseButtonUp(0))
            {
                if(points.Count==0)
                {
                    startTouch = Vector3.zero;
                    endTouch = Vector3.zero;
                    lineRenderer.enabled = false;
                    return;
                }
                if(!startCheck)
                {
                    return;
                }
                if(Vector3.Distance(points.First(),points.Last()) <= 0.1f)
                {
                    startTouch = Vector3.zero;
                    endTouch = points.First();
                    lineRenderer.enabled = false;
                    return;
                }

                if(Vector3.Distance(points.First(),points.Last()) < minDistance)
                {
                    startTouch = Vector3.zero;
                    endTouch = Vector3.zero;
                    lineRenderer.enabled = false;
                    return;
                }

                startTouch = points.First();
                endTouch = points.Last();
                OnNewPathCreated(points);
                lineRenderer.enabled = false;
                startCheck = false;
            } 
        }*/
    }

    private void SendPlayerToPortal()
    {
        mouseManager.GetSendPos(portal1.transform.position);
    }

    private IEnumerator SendPlayerToPos(Vector3 pos)
    {
        yield return new WaitForSeconds(0f);
        mouseManager.GetSendPos(pos);
    }

    private float DistanceToLastPoint(Vector3 point)
    {
        if (!points.Any())
            return Mathf.Infinity;

        return Vector3.Distance(points.Last(), point);
    }
    /*
    void ActivateHint()
    {
        hintUI.SetActive(true);
    }*/
}
