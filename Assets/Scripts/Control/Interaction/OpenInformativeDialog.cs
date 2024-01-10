using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenInformativeDialog : MonoBehaviour, InteractionInterface
{
    public int dialogueID;
    private DialogueManager dialogueManager;
    private string dialogueJsonPath = "Dialogues/InformativeDialogues";

    public void interact()
    {
        OpenDialogue();
    }

    public void OpenDialogue() {
        dialogueManager = FindObjectOfType<DialogueManager>();
        dialogueManager.StartInformativeDialog(dialogueID, dialogueJsonPath);
    }
}
