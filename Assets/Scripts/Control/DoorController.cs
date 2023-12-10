using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DoorController : MonoBehaviour
{
    public Transform destination;
    public Image image;
    private Animator transition;

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("MainCharacter")){
            StartCoroutine(MakeTransition(other));
        }
    }

    IEnumerator MakeTransition(Collider other)
    {
        transition = image.GetComponent<Animator>();
        transition.SetTrigger("FadeOut");
        yield return new WaitForSeconds(0.5f);
        other.transform.position = destination.position;
        transition.SetTrigger("FadeIn");
    }

}
