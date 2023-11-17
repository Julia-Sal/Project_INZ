using UnityEngine;

public class OpenDialog : MonoBehaviour, InteractionInterface
{
    public Dialogue dialogue;
    public void interact()
    {
        FindAnyObjectByType<DialogManager>().StartDialogue(dialogue);
    }
}
