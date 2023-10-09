using UnityEngine;

public class EnvBehaviour : MonoBehaviour
{
    public GameObject gameObject;

    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("MainCharacter"))
        {
            gameObject.SetActive(false);
        }
    }
    private void OnTriggerExit(Collider other) 
    {
        if (other.CompareTag("MainCharacter"))
        {
            gameObject.SetActive(true);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCharacter"))
        {
            gameObject.SetActive(false);
        }
    }

}
