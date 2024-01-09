using UnityEngine;

public class QuestLogic0 : MonoBehaviour
{
    public GameObject chief;
    public GameObject questManager;
    public Transform questsParent;

    void Start()
    {
        chief.AddComponent<StartQuest>();
        StartQuest startQuest = chief.GetComponent<StartQuest>();
        startQuest.questManager = questManager;
        startQuest.id = 0;
    }

    private void StartQuest3()
    {
        questsParent.Find("StartQuestTrigger3").gameObject.SetActive(true);
    }


}
