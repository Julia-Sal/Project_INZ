using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObjectSpawnItem : MonoBehaviour
{
    public GameObject item;
    public GameObject spawnedItem;
    public GameObject itemParent;


    public void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Pickup>().item.id == item.GetComponent<Pickup>().item.id)
        {
            GameObject newSpawnedItem = Instantiate(spawnedItem, itemParent.transform);
            newSpawnedItem.name = spawnedItem.name;
            newSpawnedItem.transform.position = gameObject.transform.position;
        }
    }
}

