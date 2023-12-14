using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObjectSetActive : MonoBehaviour
{
    public GameObject gameObject;
    public GameObject item;

    public void OnTriggerEnter(Collider other) {
        try
        {
            if (other.GetComponent<Pickup>().item.id == item.GetComponent<Pickup>().item.id)
            {
                gameObject.SetActive(false);
            }
        }
        catch { 
        
        }
    }
}
