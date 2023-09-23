using UnityEngine;

public class NightVision : MonoBehaviour
{
    private bool isNight;

    public Light mainLight; // G³ówne œwiat³o na scenie
    public Light lampLight; // Œwiat³o przy bohaterze
    public float lampLightIntensity;
    
    // Update is called once per frame
    void Update()
    {
        if (isNight)
        {
            {
                // Wy³¹czenie g³ównego œwiat³a na scenie
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
