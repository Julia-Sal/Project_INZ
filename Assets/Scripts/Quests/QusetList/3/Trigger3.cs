using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger3 : MonoBehaviour
{
    public GameObject cook;
    public GameObject questManager;

    void Start() {
        StartQuest startQuest = cook.AddComponent<StartQuest>();
        startQuest.questManager = questManager;
        startQuest.id = 3;
    }

}
