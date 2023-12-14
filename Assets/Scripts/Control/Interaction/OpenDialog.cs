using UnityEngine;

public class OpenDialog : MonoBehaviour, InteractionInterface
{
    public string dialogueJsonPath;
    private DialogueManager dialogueManager;
    public string npcName;
    
    public void interact()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
        dialogueManager.StartDialog(dialogueJsonPath, npcName);
    }
}
