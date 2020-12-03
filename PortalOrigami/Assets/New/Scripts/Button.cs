using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public GameObject ElectricWall;
    public bool TeleprotableButton;
    public Vector3 Destination;
    public bool camerabutton;
    public GameObject cameraview;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (camerabutton)
            {
                cameraview.SetActive(false);
            }
            else if (TeleprotableButton)
            {
                ElectricWall.transform.position = Destination;
            }
            else if(TeleprotableButton==false)
            {
                ElectricWall.SetActive(false);
            }
            
        }
    }
}
