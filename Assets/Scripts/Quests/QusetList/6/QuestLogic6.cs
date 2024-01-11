using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestLogic6 : MonoBehaviour
{
    public GameObject mound;
    public GameObject item;
    public string name;
    public GameObject endQuest;

    void Start() {
        InteractiveObjectSpawnItem interactiveObjectSpawnItem = mound.AddComponent<InteractiveObjectSpawnItem>();
        interactiveObjectSpawnItem.item = item;
        interactiveObjectSpawnItem.name = name;

        EndQuest6 endQuest6 = mound.AddComponent<EndQuest6>();
        endQuest6.item = item;
        endQuest6.name = name;
        endQuest6.endQuest = endQuest;

        
    }
}
