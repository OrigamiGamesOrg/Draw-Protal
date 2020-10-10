using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TelePort : MonoBehaviour
{
    public bool portalIsOpen = false;
    public Transform portal;
    private Transform PlayerPos;

    private Transform player = null;
    private Transform target = null;

    private Vector3 playerScale = Vector3.zero;

    private void Start() {
        PlayerPos = portal.transform.GetChild(0).transform;
    }
    /*private void Update() {
        if(playerIsOverlaping)
        {
            Vector3 portalToPlayer = player.transform.position - transform.position;
            float dotProduct = Vector3.Dot(transform.up,portalToPlayer);

            if(dotProduct < 0f)
            {
                float rotationDiff = -Quaternion.Angle(transform.rotation, portal.rotation);
                rotationDiff += 180;
                player.transform.Rotate(Vector3.up,rotationDiff);

                Vector3 positionOffset = Quaternion.Euler(0f,rotationDiff,0f) * portalToPlayer;
                player.transform.position = portal.position + positionOffset; 

                playerIsOverlaping = false;
            }
        }
    }*/
    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            portalIsOpen = true;

            //target = this.transform; 

            player = col.gameObject.transform;

            //Vector3 pos = new Vector3(this.transform.GetChild(0).transform.position.x,
            //0,this.transform.GetChild(0).transform.position.z);
            
            //player.transform.position = pos;
            //player.transform.rotation = Quaternion.LookRotation(-this.transform.GetChild(0).transform.forward);
            
            //playerScale = player.transform.localScale;

            player.GetComponent<CapsuleCollider>().enabled = false;
            player.GetComponent<NavMeshAgent>().enabled = false;

            //col.transform.rotation =  Quaternion.Euler(0,0,0);
            //Debug.Log(col.gameObject.name);
            //GameObject playerObj = col.gameObject;
            
            StartCoroutine(Teleportation(col.gameObject));
        }
    }

    /*private void Update() {
        if(player == null)
        {
            return;
        }

        if(target == this.transform)
        {
            ShrinkAnim(player.transform,target.transform,1f);    
        }
        else 
        {
            ShrinkAnim(player.transform,target.transform,-1f);    
        }

        /*Vector3 diff = player.transform.position - transform.position;
        player.transform.Translate(Time.deltaTime * diff.x * 2,0,Time.deltaTime * diff.z * 2);
        float xScale = player.transform.localScale.x - Time.deltaTime / 10;
        xScale = Mathf.Clamp(xScale,0,0.4f);
        float yScale = player.transform.localScale.y - Time.deltaTime / 10;
        yScale = Mathf.Clamp(yScale,0,0.4f);
        float zScale = player.transform.localScale.z - Time.deltaTime / 10;
        zScale = Mathf.Clamp(zScale,0,0.4f);
        player.transform.localScale = new Vector3(xScale,yScale,zScale);*/
    //}

    /*private void ShrinkAnim(Transform player,Transform target,float dir)
    {
        Vector3 diff = (player.position - target.position) * dir;
        player.transform.Translate(Time.deltaTime * diff.x * 2,0,Time.deltaTime * diff.z * 2);

        float xScale = player.transform.localScale.x - ((Time.deltaTime / 20) * dir);
        xScale = Mathf.Clamp(xScale,0f,playerScale.x);
        
        float yScale = player.transform.localScale.y - ((Time.deltaTime / 20) * dir);
        yScale = Mathf.Clamp(yScale,0,playerScale.y);
        
        float zScale = player.transform.localScale.z - ((Time.deltaTime / 20) * dir) ;
        zScale = Mathf.Clamp(zScale,0,playerScale.z);

        player.transform.localScale = new Vector3(xScale,yScale,zScale);

        if(player.transform.localScale.magnitude <= 0f && target==this.transform)
        {
            Debug.Log("Teleport");
            StartCoroutine(Teleportation(player.gameObject));
        }
    }*/

    private IEnumerator Teleportation(GameObject _player)
    {
        //player = null;
        //target = null;
        _player.SetActive(false);

        yield return new WaitForSeconds(1f);

        _player.transform.position = new Vector3(PlayerPos.position.x, 0f, PlayerPos.position.z);
        _player.transform.rotation =  Quaternion.LookRotation(PlayerPos.forward);
        //_player.transform.localScale = playerScale;

        //player = _player.transform;
        //target = PlayerPos;

        _player.SetActive(true);
        
        yield return new WaitForSeconds(0.2f);

        portal.gameObject.SetActive(false);
        
        gameObject.SetActive(false);

        //_player.transform.localScale = playerScale;
        //_player.transform.position = PlayerPos.position;
        //_player.transform.rotation =  Quaternion.LookRotation(PlayerPos.forward);

        _player.GetComponent<NavMeshAgent>().enabled = true;
        _player.GetComponent<CapsuleCollider>().enabled = true;

        //player = null;
        //target = null;

        portalIsOpen = false;
    }
}
