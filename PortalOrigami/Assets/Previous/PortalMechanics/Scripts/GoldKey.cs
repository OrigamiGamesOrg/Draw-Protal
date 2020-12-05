using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldKey : MonoBehaviour
{
    public bool isKeyCollected = false;

    public GameObject collectionEffect;
    public GameObject button;


    private void OnTriggerEnter(Collider other)
    {
        button.SetActive(true);
    }

    public void KeyCollection()
    {
        GameObject.FindGameObjectWithTag("Door").GetComponent<Door>().RemoveKey(this.gameObject);
        Destroy(gameObject);
        GameObject effect = Instantiate(collectionEffect, transform.position, Quaternion.identity);
        Destroy(effect, 2f);
        button.SetActive(false);
    }
}
