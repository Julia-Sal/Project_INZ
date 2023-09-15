using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Env_behaviour : MonoBehaviour
{
    public GameObject floor;

    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("MainCharacter"))
        {
            floor.SetActive(false);
        }
    }
    private void OnTriggerExit(Collider other) 
    {
        if (other.CompareTag("MainCharacter"))
        {
            floor.SetActive(true);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCharacter"))
        {
            floor.SetActive(false);
        }
    }

}
