using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Joystick joystick;
    public Rigidbody rb;
    private Animator anim;
    public GameObject EndCanvas;
    public GameObject[] confetties;
    public float moveForce;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {

        rb.velocity = new Vector3(joystick.Horizontal * moveForce, rb.velocity.y, joystick.Vertical * moveForce);

        if (joystick.Horizontal <= -0.1f || joystick.Horizontal >= 0.1f || joystick.Vertical >= 0.1f || joystick.Vertical <= -0.1f)
        {
            transform.rotation = Quaternion.LookRotation(rb.velocity).normalized;
        }

        if (!GameManager.instance.isPlaying)
        {
            return;
        }
        anim.SetFloat("Blend", rb.velocity.magnitude);
        if (rb.velocity.magnitude >= 0.5f)
        {
            anim.SetBool("isMoving", true);
        }
        else
        {
            anim.SetBool("isMoving", false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Door"))
        {
            gameObject.SetActive(false);
            for (int i = 0; i < confetties.Length; i++)
            {
                confetties[i].SetActive(true);
            }
            EndCanvas.SetActive(true);


            //GameManager.instance.LevelComplete();
            // Debug.Log("Level Complete");
        }

        if (other.gameObject.CompareTag("NextDoor"))
        {
            GameManager.instance.NextRoom();
            Debug.Log("Next Room");
        }

        if (other.gameObject.CompareTag("Electric"))
        {
            GameManager.instance.GetCaught();
            this.gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("DoorRoom"))
        {
            GameManager.instance.DoorRoom();
        }
    }
}
