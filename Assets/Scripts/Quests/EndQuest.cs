using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndQuest : MonoBehaviour
{
    public int id;
    public GameObject questManager;
    public GameObject quest;

    public void EndQuestNormal()
    {
        QuestManager manager = questManager.GetComponent<QuestManager>();
        manager.EndQuest(id);
        quest.SetActive(false);

    }


}
