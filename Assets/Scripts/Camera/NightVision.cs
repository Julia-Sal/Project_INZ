using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightVision : MonoBehaviour
{
    public bool isNight = true;

    public Transform player; // Obiekt, kt�ry b�dziemy �ledzi� (oznaczony tagiem "Player")
    public Light mainLight; // G��wne �wiat�o na scenie
    public Light characterLight; // �wiat�o przy bohaterze

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
                // Wy��czenie g��wnego �wiat�a na scenie
                mainLight.enabled = false;

                // W��czenie i ustawienie pozycji �wiat�a przy bohaterze
                characterLight.enabled = true;
                characterLight.transform.position = new Vector3(player.position.x, player.position.y, characterLight.transform.position.z);
            }
        }
        else 
        {

        }
    }

}
