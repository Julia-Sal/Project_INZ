using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractWithNPC : MonoBehaviour
{
    public GameObject npc;

    public void OnTriggerEnter(Collider other)
    {
        if (other.name == npc.name) {
            gameObject.SetActive(false);
        }
    }
}
