using System.Collections;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public Transform destination;
    private Animator animator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCharacter")){
            //StartCoroutine(AnimationOpenDoor());
            moveCharacter(other);
            
        }
    }
    /*
    IEnumerator AnimationOpenDoor()
    {
        animator = GetComponent<Animator>();
        animator.SetTrigger("OpenDoor");

        while (!animator.IsInTransition(0))
        {
            Debug.Log("trwa");
        }

    }*/

    public void moveCharacter(Collider other)
    {
        other.transform.position = destination.position;
    }
}
