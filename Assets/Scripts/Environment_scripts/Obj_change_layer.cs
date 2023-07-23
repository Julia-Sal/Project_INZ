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

    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        sortingGroup.sortingOrder = 6;
        Debug.Log(sortingGroup.sortingOrder);
    }

    private void OnTriggerExit(Collider other)
    {
        sortingGroup.sortingOrder = 1;
        Debug.Log(sortingGroup.sortingOrder);
    }
}
