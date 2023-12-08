using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeDialogue : MonoBehaviour
{
    public void ChangeDialog(GameObject npc, string newDialogue)
    {
        OpenDialog dialogue = npc.gameObject.GetComponent<OpenDialog>();
        dialogue.dialogueJsonPath = newDialogue;
    }
}
