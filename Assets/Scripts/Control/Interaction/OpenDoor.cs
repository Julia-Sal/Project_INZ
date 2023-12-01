using System.Collections;
using UnityEngine;

public class OpenDoor : MonoBehaviour, InteractionInterface
{
    public GameObject showObject;
    public void interact(){
        gameObject.SetActive(false);
        showObject.SetActive(true);
    }

}
