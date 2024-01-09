using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger0 : MonoBehaviour
{
    public Transform questsParent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCharacter")) {
            StartQuest3();
        }
    }

    private void StartQuest3()
    {
        questsParent.Find("StartQuestTrigger3").gameObject.SetActive(true);
    }
}
