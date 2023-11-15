using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartQuest : MonoBehaviour
{
    public Quest quest;

    private void OnTriggerEnter(Collider other)
    {
        QuestGiver questGiver = new QuestGiver();
        questGiver.newQuest(quest);
    }
}
