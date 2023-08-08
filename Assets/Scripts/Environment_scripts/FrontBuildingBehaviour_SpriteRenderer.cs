using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontBuildingBehaviour_SpriteRenderer : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    private float newAlpha = 0.3f;
    private float standardAlpha = 1.0f;

    private void OnTriggerEnter(Collider collider)
    {
        ChangeSpriteAlpha(newAlpha);
    }

    private void OnTriggerExit(Collider other)
    {
        ChangeSpriteAlpha(standardAlpha);
    }

    void ChangeSpriteAlpha(float newAlpha)
    {
        Debug.Log(newAlpha);
        Color color = spriteRenderer.color;
        color.a = newAlpha;
        spriteRenderer.color = color;

    }
}
