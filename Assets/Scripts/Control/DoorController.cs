using UnityEngine;

public class DoorController : MonoBehaviour
{
    public Transform destination;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCharacter")){
            other.transform.position = destination.position;
        }
    }
}
