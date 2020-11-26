using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldKey : MonoBehaviour
{
    public bool isKeyCollected = false;

    public GameObject collectionEffect;

    private void OnTriggerEnter(Collider other)
    {
        GameObject.FindGameObjectWithTag("Door").GetComponent<Door>().RemoveKey(this.gameObject);
        Destroy(gameObject);
        GameObject effect = Instantiate(collectionEffect, transform.position, Quaternion.identity);
        Destroy(effect, 2f);
    }
}
