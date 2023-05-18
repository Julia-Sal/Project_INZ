using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obj_Movements : MonoBehaviour
{
    public Animator animator;
    private bool isPlayerMoving = false;
    public Rigidbody playerRigidbody;
    public float minVelocityMagnitude = 0f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCharacter"))
        {

            animator.SetTrigger("TriggerMove");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCharacter") && IsPlayerMoving())
        {
            animator.SetTrigger("TriggerMove");
        }
        else 
        {
            animator.SetTrigger("TriggerStop");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCharacter"))
        {
            animator.SetTrigger("TriggerStop");
        }
    }

    private bool IsPlayerMoving()
    {
        return playerRigidbody.velocity.magnitude >= minVelocityMagnitude;
    }

}
