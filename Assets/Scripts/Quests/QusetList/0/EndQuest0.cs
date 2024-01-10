using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndQuest0 : MonoBehaviour
{
    public GameObject cook;
    public GameObject questManager;
    public GameObject quest;

    void Start()
    {
        EndQuest endQuest = cook.AddComponent<EndQuest>();
        endQuest.questManager = questManager;
        endQuest.id = 0;
        endQuest.quest = quest;
    }

}
