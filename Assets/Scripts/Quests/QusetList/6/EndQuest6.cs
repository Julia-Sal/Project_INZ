using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndQuest6 : MonoBehaviour
{
    public GameObject item;
    public string name;
    public GameObject endQuest;


    public void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Pickup>() != null && other.GetComponent<Pickup>().item.id == item.GetComponent<Pickup>().item.id)
        {
            endQuest.GetComponent<EndQuest>().EndQuestNormal();
            
            StartQuestTrigger startQuestTrigger = endQuest.GetComponent<StartQuestTrigger>();
            startQuestTrigger.StartTrigger(startQuestTrigger.questTrigger, startQuestTrigger.questsParent);
            
            Destroy(gameObject.GetComponent<InteractiveObjectSpawnItem>());
            //Destroy(gameObject.GetComponent<EndQuest6>());
        }
    }
}
