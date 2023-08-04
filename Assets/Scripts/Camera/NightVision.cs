using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightVision : MonoBehaviour
{
    public bool isNight = true;

    public Transform player; // Obiekt, który bêdziemy œledziæ (oznaczony tagiem "Player")
    public Light mainLight; // G³ówne œwiat³o na scenie
    public Light characterLight; // Œwiat³o przy bohaterze

    // Start is called before the first frame update
    void Start()
    { 

    }

    // Update is called once per frame
    void Update()
    {
        if (isNight)
        {
            {
                // Wy³¹czenie g³ównego œwiat³a na scenie
                mainLight.enabled = false;

                // W³¹czenie i ustawienie pozycji œwiat³a przy bohaterze
                characterLight.enabled = true;
                characterLight.transform.position = new Vector3(player.position.x, player.position.y, characterLight.transform.position.z);
            }
        }
        else 
        {

        }
    }

}
