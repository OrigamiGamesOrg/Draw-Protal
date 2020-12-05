using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    
    public List<GameObject> keys = new List<GameObject>();
    public bool NextLevel = false;
    public Transform nextDoor;

    

    private void Update()
    {
        if (keys.Count <= 0)
        {
            if (NextLevel)
            {
                transform.tag = "NextDoor";
                nextDoor.tag = "Door";
            }
            Debug.Log(keys.Count);
            GetComponentInChildren<Animator>().enabled = true;
            GetComponent<BoxCollider>().isTrigger = true;
            this.enabled = false;
            return;
        }
    }

    
    public void RemoveKey(GameObject key)
    {
        keys.Remove(key);
    }    

   
}
