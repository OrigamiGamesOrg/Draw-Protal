
using UnityEngine;
using UnityEngine.AI;

public class Player_Controller : MonoBehaviour
{
    private NavMeshAgent agent;
    private Animator anim;
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!GameManager.instance.isPlaying)
        {
            return;
        }
        anim.SetFloat("Blend", agent.velocity.magnitude);
        if (agent.velocity.magnitude >= 0.5f)
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
            GameManager.instance.LevelComplete();
            Debug.Log("Level Complete");
        }

        if (other.gameObject.CompareTag("NextDoor"))
        {
            GameManager.instance.NextRoom();
            Debug.Log("Next Room");
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
