using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ObjChangeLayer : MonoBehaviour
{
    public Transform transform; // Zmieniany obiekt
    public int onTriggerEnterLayer;
    public int onTriggerExitLayer;

    private UnityEngine.Rendering.SortingGroup sortingGroup; // Reference to the Sorting Group component

    void Start()
    {
        sortingGroup = transform.GetComponent<SortingGroup>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCharacter"))
        {
            sortingGroup.sortingOrder = onTriggerEnterLayer;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCharacter"))
        {
            sortingGroup.sortingOrder = onTriggerExitLayer;
            Debug.Log(sortingGroup.sortingOrder);
        }
    }
}
