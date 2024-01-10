using UnityEngine;

public class QuestLogic3 : MonoBehaviour
{
    public GameObject bowl;
    public GameObject player;
    public GameObject questManager;
    public Transform questsParent;
    public string questTrigger1;
    public string questTrigger2;
    public GameObject quest;

    void Start()
    {
        InteractWithNPC component = bowl.AddComponent<InteractWithNPC>();
        component.npc = player;

        SetNewDialogue setNewDialogue = bowl.AddComponent<SetNewDialogue>();
        setNewDialogue.newDialogueNumber = 1;
        setNewDialogue.npcName = "cook";

        EndQuest componentEnd = bowl.AddComponent<EndQuest>();
        componentEnd.id = 3;
        componentEnd.questManager = questManager;
        componentEnd.quest = quest;

        EndQuest3 endQuest3 = bowl.AddComponent<EndQuest3>();
       

        bowl.AddComponent<StartQuestTrigger>();
        StartQuestTrigger startQuestTrigger1 = bowl.GetComponent<StartQuestTrigger>();
        startQuestTrigger1.questsParent = questsParent;
        startQuestTrigger1.questTrigger = questTrigger1;

        StartQuestTrigger startQuestTrigger2 = bowl.AddComponent<StartQuestTrigger>();
        startQuestTrigger2.questsParent = questsParent;
        startQuestTrigger2.questTrigger = questTrigger2;

    }

}
