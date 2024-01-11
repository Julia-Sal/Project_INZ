using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetNewDialogue : MonoBehaviour
{
    public int newDialogueNumber;
    public string npcName;

    private void OnTriggerEnter(Collider other)
    {
        SetDialogue();
    }

    private void OnMouseDown()
    {
        SetDialogue();
    }

    public void SetDialogue()
    {
        if (newDialogueNumber != 0 && npcName != null)
        {
            SaveDialogState saveDialogState = new SaveDialogState();
            saveDialogState.SaveData(npcName, newDialogueNumber);
        }
    }
}
