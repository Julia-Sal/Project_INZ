using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObjectSpawnItem : MonoBehaviour
{
    public GameObject item;
    public string name;


    public void OnTriggerEnter(Collider other) {
        Debug.Log(other.GetComponent<Pickup>().item.id);
        Debug.Log(item.GetComponent<Pickup>().item.id);
        if (other.GetComponent<Pickup>().item.id == item.GetComponent<Pickup>().item.id && gameObject.layer == 10) {
            Vector3 targetPosition = gameObject.transform.position;
            CreateObject createObject = new CreateObject();
            createObject.generateObject(targetPosition, name);
            gameObject.layer = 12;
        }
    }
}

