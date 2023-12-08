using UnityEngine;

public class StartQuest : MonoBehaviour
{
    public int id;
    public GameObject chief;
    public string newPath;
    private void OnTriggerEnter(Collider other)
    {
        QuestGiver questGiver = new QuestGiver();
        questGiver.newQuest(id);

        if(chief!=null && newPath != null) { 
            ChangeDialogue changeDialogue = new ChangeDialogue();
            changeDialogue.ChangeDialog(chief, newPath);
        }
    }
}
