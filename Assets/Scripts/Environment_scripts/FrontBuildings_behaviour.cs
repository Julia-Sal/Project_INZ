using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontBuildings_behaviour : MonoBehaviour
{
    public Material material;
    private float newAlpha = 0.3f;
    private float standardAlpha = 1.0f;

    private void OnTriggerEnter(Collider collider)
    {
        ChangeMaterialAlpha(newAlpha);
    }

    private void OnTriggerExit(Collider other)
    {
        ChangeMaterialAlpha(standardAlpha);
    }

    void ChangeMaterialAlpha(float newAlpha)
    {
        Debug.Log(newAlpha);
        Color color = material.color;
        color.a = newAlpha;
        material.color = color;

    }


}
