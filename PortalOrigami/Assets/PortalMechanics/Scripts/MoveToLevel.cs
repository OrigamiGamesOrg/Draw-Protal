using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToLevel : MonoBehaviour
{
    public Vector3 pos;
    [Range(0f,0.1f)]
    public float moveSpeed = 0.05f;
    private Vector3 movePos = Vector3.zero;
    private void Update() {
        if(movePos == Vector3.zero)
        {
            return;
        }
        transform.position = Vector3.Lerp(transform.position,movePos,moveSpeed);
        if(Vector3.Distance(transform.position,movePos) <= 0.1f)
        {
            transform.position = movePos;
            this.enabled = false;
        }
    }
    public void MoveToNextPos()
    {
        movePos = pos;
    }
}
