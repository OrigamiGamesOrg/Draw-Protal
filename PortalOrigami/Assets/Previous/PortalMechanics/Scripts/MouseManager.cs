using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class MouseManager : MonoBehaviour
{
    public LayerMask clickableLayer;

    public EventVector3 OnClickEnvironment;

    private GameObject player;

    public bool enableThis = false;
    
    private void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update() {
        if(!GameManager.instance.isPlaying)
        {
            return;
        }
        
        if(!enableThis)
        {
            return;
        }
        RaycastHit hit;

        if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition) , out hit, Mathf.Infinity, clickableLayer.value))
        {
            if(Input.GetMouseButtonDown(0))
            {
                StartCoroutine(pause(hit.point));
            }
        }
    }

    public IEnumerator pause(Vector3 hit)
    {
        yield return new WaitForSeconds(0.2f);
        GetSendPos(hit);
    }

    public void GetSendPos(Vector3 hit)
    {
        if(!player.activeSelf || !player.GetComponent<NavMeshAgent>().enabled)
        {
            return;
        }
        OnClickEnvironment.Invoke(hit);
    }
}

[System.Serializable]
public class EventVector3 : UnityEvent<Vector3> { }