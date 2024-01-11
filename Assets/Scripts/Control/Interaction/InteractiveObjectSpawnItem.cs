using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObjectSpawnItem : MonoBehaviour
{
    public GameObject item;
    public string name;


    public void OnTriggerEnter(Collider other) {
        if (other.GetComponent<Pickup>() != null && other.GetComponent<Pickup>().item.id == item.GetComponent<Pickup>().item.id) {
            Vector3 targetPosition = gameObject.transform.position;
            CreateObject createObject = new CreateObject();
            createObject.generateObject(targetPosition, name);
        }
    }
}

