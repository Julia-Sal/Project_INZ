using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayVision : MonoBehaviour
{
    private string night = "night_";
    private string day = "day_";
    public Light mainLight; // G³ówne œwiat³o na scenie
    public Light lampLight; // Œwiat³o przy bohaterze
    public float lampLightIntensity;

    void RemoveNightObjects()
    {
        GameObject[] allObjects = Resources.FindObjectsOfTypeAll<GameObject>();

        foreach (GameObject obj in allObjects)
        {
            if (obj.name.StartsWith(day))
            {
                obj.SetActive(true);
            }
        }

        foreach (GameObject obj in allObjects)
        {
            if (obj.name.StartsWith(night))
            {
                obj.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCharacter"))
        {
            RemoveNightObjects();
            mainLight.intensity = 1f;
            lampLight.intensity = 0f;
        }
    }
}
