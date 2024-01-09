using UnityEngine;

public class OpenDialog : MonoBehaviour, InteractionInterface
{
    public string dialogueJsonPath;
    public DialogueManager dialogueManager;
    public string npcName;
    
    public void interact() {
        dialogueManager.StartDialog(dialogueJsonPath, npcName);
    }
}
