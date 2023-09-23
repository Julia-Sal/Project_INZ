using UnityEngine;

public class NightVision : MonoBehaviour
{
    private bool isNight;

    public Light mainLight; // G��wne �wiat�o na scenie
    public Light lampLight; // �wiat�o przy bohaterze
    public float lampLightIntensity;
    
    // Update is called once per frame
    void Update()
    {
        if (isNight)
        {
            {
                // Wy��czenie g��wnego �wiat�a na scenie
                mainLight.intensity = 0.2f;
                lampLight.intensity = lampLightIntensity;

            }
        }
        else
        {
            mainLight.intensity = 1f;
            lampLight.intensity = 0f;
        }

    }
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("MainCharacter"))
        {
            isNight = true;
        }
    }
    

}
