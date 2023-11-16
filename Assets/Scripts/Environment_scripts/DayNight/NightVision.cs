using UnityEngine;

public class NightVision : MonoBehaviour
{
    private string day = "day_";
    private string night = "night_";
    public Light mainLight; // G³ówne œwiat³o na scenie
    public Light lampLight; // Œwiat³o przy bohaterze
    public float lampLightIntensity;
    
    
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("MainCharacter"))
        {
            RemoveDayObjects();
            mainLight.intensity = 0.2f;
            lampLight.intensity = lampLightIntensity;
        }
    }

    void RemoveDayObjects()
    {
        GameObject[] allObjects = Resources.FindObjectsOfTypeAll<GameObject>();

        foreach (GameObject obj in allObjects)
        {
            if (obj.name.StartsWith(day))
            {
                obj.SetActive(false);
            }
        }

        foreach (GameObject obj in allObjects)
        {
            if (obj.name.StartsWith(night))
            {
                obj.SetActive(true);
            }
        }
    }


}
