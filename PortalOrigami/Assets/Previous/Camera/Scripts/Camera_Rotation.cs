using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Rotation : MonoBehaviour
{
    private GameObject cam;

    public float rotationSpeed = 1f;
    public float maxAngle = 90f , minAngle = 0f;

    private void Start() {
        cam = transform.GetChild(0).gameObject;
    }

    private void Update() {
        if(!GameManager.instance.isPlaying)
        {
            return;
        }
        if(cam.transform.localEulerAngles.y - 360 >= maxAngle || cam.transform.localEulerAngles.y - 360 <= minAngle)
        {
            rotationSpeed = -rotationSpeed;
        }

        cam.transform.localEulerAngles = new Vector3(0,cam.transform.localEulerAngles.y + rotationSpeed,0);
    }
}
