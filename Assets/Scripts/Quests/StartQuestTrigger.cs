using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartQuestTrigger : MonoBehaviour
{
    public string questTrigger;
    public Transform questsParent;


    public void StartTrigger(string questTrigger, Transform questsParent)
    {
        questsParent.Find(questTrigger).gameObject.SetActive(true);
    }
}
