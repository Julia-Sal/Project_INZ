using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObjectSpawnItem : MonoBehaviour, InteractionInterface
{
    public GameObject item;

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("sprawdzam");
        if (other.GetComponent<Pickup>().item.id == item.GetComponent<Pickup>().item.id)
        { 
            Debug.Log("poprawnyItem");
        }
    }

    public void interact() {
    }
}
