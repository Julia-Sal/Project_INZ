using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Obj_change_layer : MonoBehaviour
{
    public Transform stairs; // The object whose Sorting Group will be changed

    private UnityEngine.Rendering.SortingGroup sortingGroup; // Reference to the Sorting Group component

    void Start()
    {
        sortingGroup = stairs.GetComponent<SortingGroup>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCharacter"))
        {
            sortingGroup.sortingOrder = 6;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCharacter"))
        {
            sortingGroup.sortingOrder = 4;
            Debug.Log(sortingGroup.sortingOrder);
        }
    }
}
