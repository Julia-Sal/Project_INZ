using UnityEngine;

public class QuestLogic3 : MonoBehaviour
{
    public GameObject bowl;
    public GameObject player;
    public GameObject questManager;

    void Start()
    {
        bowl.AddComponent<InteractWithNPC>();
        InteractWithNPC component = bowl.GetComponent<InteractWithNPC>();
        component.npc = player;

        bowl.AddComponent<SetNewDialogue>();
        SetNewDialogue setNewDialogue = bowl.GetComponent<SetNewDialogue>();
        setNewDialogue.newDialogueNumber = 1;
        setNewDialogue.npcName = "cook";

        bowl.AddComponent<EndQuest>();
        EndQuest componentEnd = bowl.GetComponent<EndQuest>();
        componentEnd.id = 3;
        componentEnd.questManager = questManager;
        componentEnd.npc = player;

        

    }

}
