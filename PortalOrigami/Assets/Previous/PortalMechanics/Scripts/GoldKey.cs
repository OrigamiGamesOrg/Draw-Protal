using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldKey : MonoBehaviour
{
    public bool isKeyCollected = false;

    public GameObject collectionEffect;
    public GameObject button;
    public GameObject door;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            button.SetActive(true);
        }
    }

    public void KeyCollection()
    {
        Debug.Log("Key Collected");
        Handheld.Vibrate();
        door.GetComponentInChildren<Door>().RemoveKey(this.gameObject);
        Debug.Log("Key Destroyed");
        Destroy(gameObject);
        GameObject effect = Instantiate(collectionEffect, transform.position, Quaternion.identity);
        Destroy(effect, 2f);
        button.SetActive(false);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            button.SetActive(false);
        }
    }
}
