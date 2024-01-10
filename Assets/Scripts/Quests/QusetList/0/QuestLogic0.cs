using UnityEngine;

public class QuestLogic0 : MonoBehaviour
{
    public GameObject chief;
    public GameObject questManager;
    public Transform questsParent;
    public string questTrigger3;

    void Start()
    {
        chief.AddComponent<StartQuest>();
        StartQuest startQuest = chief.GetComponent<StartQuest>();
        startQuest.questManager = questManager;
        startQuest.id = 0;

        chief.AddComponent<StartQuestTrigger>();
        StartQuestTrigger startQuestTrigger = chief.GetComponent<StartQuestTrigger>();
        startQuestTrigger.questsParent = questsParent;
        startQuestTrigger.questTrigger = questTrigger3;
    }


}
