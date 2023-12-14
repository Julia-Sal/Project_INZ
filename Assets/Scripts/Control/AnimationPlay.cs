using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPlay : MonoBehaviour
{
    public string onEnter;
    public string onExit;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCharacter"))
        {
            gameObject.GetComponent<Animator>().Play(onEnter);

        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCharacter"))
        {
            gameObject.GetComponent<Animator>().Play(onExit);
        }
    }
}
