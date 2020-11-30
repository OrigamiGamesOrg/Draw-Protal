using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public GameObject ElectricWall;
    public bool TeleprotableButton;
    public Vector3 Destination;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (TeleprotableButton)
            {
                ElectricWall.transform.position = Destination;
            }
            else
            {
                ElectricWall.SetActive(false);
            }
        }
    }
}
