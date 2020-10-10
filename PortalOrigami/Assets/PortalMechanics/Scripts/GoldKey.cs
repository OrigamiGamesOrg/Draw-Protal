using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldKey : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        GameObject.FindGameObjectWithTag("Door").GetComponent<Door>().RemoveKey(this.gameObject);
        Destroy(gameObject);
    }
}
