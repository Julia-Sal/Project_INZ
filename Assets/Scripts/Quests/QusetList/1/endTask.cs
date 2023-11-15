using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endTask : MonoBehaviour
{
    public Quest quest;
    public Task task;

    private void OnTriggerEnter(Collider other)
    {
        if(!task.isComplete){
            task.isComplete = true;
            quest.endQuestIfPossible();
        }
        
    }
}
