using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontBuildings_behaviour : MonoBehaviour
{
    public Material material;
    private float newAlpha = 0.3f;

    private void OnTriggerEnter(Collider collider)
    {
        ChangeMaterialAlpha(newAlpha);
    }

    void ChangeMaterialAlpha(float newAlpha)
    {
        Debug.Log(newAlpha);
        Color color = material.color;
        color.a = newAlpha;
        material.color = color;
    }


}
