using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewQuest", menuName = "Quest/Create New Quest")]
public class Quest:ScriptableObject
{
    public string questName;
    public bool isComplete = false;
    public bool isActive = false;
    public string description;
    public List<Task> tasks = new List<Task>();
    private QuestManager questManager;

    private bool CheckConditions() {
        foreach (var task in tasks)
        {
            if (!task.isComplete)
            {
                Debug.Log("task is not complete!");
                return false;
            }
        }
        Debug.Log("task is complete!");
        return true;
    }

    public void endQuestIfPossible() {
        if (CheckConditions()) {
            isActive = false;
            isComplete = true;
            Debug.Log("1");

            questManager = QuestManager.instance;
            if (questManager != null)
            {
                questManager.completedQuests.Add(this);
                questManager.activeQuests.Remove(this);

                //w przysz³oœci do usuniêcia:
                // Wyœwietl zawartoœæ activeQuests HashSet w konsoli
                Debug.Log("Active Quests:");
                foreach (var quest in questManager.activeQuests)
                {
                    Debug.Log(quest.questName);
                }

                // Wyœwietl zawartoœæ completedQuests HashSet w konsoli
                Debug.Log("Completed Quests:");
                foreach (var quest in questManager.completedQuests)
                {
                    Debug.Log(quest.questName);
                }
                //usuniêcie do tego miejsca
            }
        }
    }
}
