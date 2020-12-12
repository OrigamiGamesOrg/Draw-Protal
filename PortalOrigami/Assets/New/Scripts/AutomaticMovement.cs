using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AutomaticMovement : MonoBehaviour
{
    private NavMeshAgent nav;
    public GameObject Portal1, Portal2;
    public GameObject ClosestPortal=null;
    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, Portal1.transform.position) < Vector3.Distance(transform.position, Portal2.transform.position))
        {
            ClosestPortal = Portal1.gameObject;
        }
        else
        {
            ClosestPortal = Portal2.gameObject;
        }

        /*if (Portal1 != null && Portal2 != null)
        {
            if (Vector3.Distance(this.transform.position, Portal1.transform.position) < Vector3.Distance(this.transform.position, Portal2.transform.position))
            {
                ClosestPortal = Portal1;
            }
            else
            {
                ClosestPortal = Portal2;
            }
        }
        else
        {
            ClosestPortal = null;
        }
        if(Portal1!=null && Portal2 != null)
        {
            nav.SetDestination(ClosestPortal.transform.position);
        }*/
    }
}
