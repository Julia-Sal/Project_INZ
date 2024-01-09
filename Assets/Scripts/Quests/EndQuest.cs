using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndQuest : MonoBehaviour
{
    public int id;
    public GameObject questManager;
    public GameObject npc;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == npc.name)
        {
            EndQuestNormal();
        }
    }

    public void EndQuestNormal()
    {
        QuestManager manager = questManager.GetComponent<QuestManager>();
        manager.EndQuest(id);

    }


}
