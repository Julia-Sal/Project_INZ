using UnityEngine;

public class QuestGiver : MonoBehaviour
{
    private QuestManager questManager;
    

    public void newQuest(Quest quest) {
        questManager = QuestManager.instance;
        quest.isActive = true;
        questManager.activeQuests.Add(quest);
    }

}
