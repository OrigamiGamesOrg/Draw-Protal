using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PinchAndZoom : MonoBehaviour
{
    public float Perspectivezoomspeed=0.5f,Orthozoomspeed=0.5f;
    private Camera camera;
    public float OrthoLimit;
    private GameObject checkifpaused;
    Vector3 touchStart;
    
    public GameObject joystick;
    public float joystickenablebound, joystickdisalebound;
    public Joystick js;
    
    float Horizontalmove,Verticalmove;
    public float moveSpeed;
    public float minX, maxX, minY, maxY;
    




    void Awake()
    {
        camera = Camera.main;
        checkifpaused = GameObject.Find("GameManager");
        
        
    }
   
    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isPlaying)
        {
            if (Input.touchCount == 2)
            {
                Touch touchzero = Input.GetTouch(0);
                Touch touchone = Input.GetTouch(1);

                Vector2 touchzero_prevpos = touchzero.position - touchzero.deltaPosition;
                Vector2 touchone_prepos = touchone.position - touchone.deltaPosition;

                float prevTouchDeltaMag = (touchzero_prevpos - touchone_prepos).magnitude;
                float touchDeltaMag = (touchzero.position - touchone.position).magnitude;

                float DeltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

                if (camera.orthographic)
                {

                    camera.orthographicSize += DeltaMagnitudeDiff * Orthozoomspeed;
                    camera.orthographicSize = Mathf.Max(camera.orthographicSize, OrthoLimit);
                    camera.orthographicSize = Mathf.Min(camera.orthographicSize, 19f);

          
                }
                else
                {
                    camera.fieldOfView += DeltaMagnitudeDiff * Perspectivezoomspeed;
                    camera.fieldOfView = Mathf.Clamp(camera.fieldOfView, 0.1f, 179.99f);
                }
            }
            if (camera.orthographicSize < joystickenablebound)
            {
                joystick.SetActive(true);
                Horizontalmove = js.Horizontal * moveSpeed;
                Verticalmove = js.Vertical * moveSpeed;
                Debug.Log(Horizontalmove);
                camera.transform.Translate(Horizontalmove,Verticalmove, 0);
   
            }
            if (camera.orthographicSize > joystickdisalebound)
            {
                joystick.SetActive(false);
            }
            Vector3 temp = transform.position;
            if (temp.x >= maxX)
            {
                temp.x = maxX;
            }
            if (temp.x <= minX)
            {
                temp.x = minX;
            }
            if (temp.y >= maxY)
            {
                temp.y = maxY;
            }
            if (temp.y <= minY)
            {
                temp.y = minY;
            }
            transform.position = temp;





        }
    }
        

   
}
