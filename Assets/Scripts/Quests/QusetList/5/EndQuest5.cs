using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndQuest5 : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCharacter"))
        {
            gameObject.GetComponent<EndQuest>().EndQuestNormal();

            StartQuestTrigger startQuestTrigger = gameObject.GetComponent<StartQuestTrigger>();
            startQuestTrigger.StartTrigger(startQuestTrigger.questTrigger, startQuestTrigger.questsParent);
        }

    }
}
