using UnityEngine;

public class OpenDialog : MonoBehaviour, InteractionInterface
{
    public string dialogueJsonPath;
    public DialogueManager dialogueManager;
    public string npcName;
    
    public void interact() {
        dialogueManager.StartDialog(dialogueJsonPath, npcName);

        if (gameObject.GetComponent<StartQuest>() != null) {
            gameObject.GetComponent<StartQuest>().StartQuestAfterDialogue();
        }

        if (gameObject.GetComponent<StartQuestTrigger>() != null){
            StartQuestTrigger startQuestTrigger = gameObject.GetComponent<StartQuestTrigger>();
            startQuestTrigger.StartTrigger(startQuestTrigger.questTrigger, startQuestTrigger.questsParent);
        }

        if (gameObject.GetComponent<EndQuest>() != null) {
            gameObject.GetComponent<EndQuest>().EndQuestNormal();
        }
    }
}
