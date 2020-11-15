using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDownAnim : MonoBehaviour
{
    public bool Move = true;    ///gives you control in inspector to trigger it or not
    public Vector3 MoveVector = Vector3.up; //unity already supplies us with a readonly vector representing up and we are just chaching that into MoveVector
    public float MoveRange = 0.5f; //change this to increase/decrease the distance between the highest and lowest points of the bounce
    public float MoveSpeed = 5f; //change this to make it faster or slower

    private Transform thisTransform;

    Vector3 startPosition; //used to cache the start position of the transform
    void Start()
    {
        thisTransform = GetComponent<Transform>();
        startPosition = thisTransform.transform.position;
    }
    void Update()
    {
        if (Move)
        {
            thisTransform.transform.position = startPosition + MoveVector * (MoveRange * Mathf.Sin(Time.timeSinceLevelLoad * MoveSpeed));
        }
           

    }
}
