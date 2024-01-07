using UnityEngine;

public class StartQuest : MonoBehaviour
{
    public int id;
    public int newDialogueNumber;
    public string npcName;
    public GameObject questManager;

    private void OnTriggerEnter(Collider other) {
        StartQuestNormal();
        SetDialogue();
    }

    public void StartQuestAfterDialogue() {

    }

    private void OnMouseDown() {
        StartQuestNormal();
       // SetDialogue();
    }

    public void StartQuestNormal() {
        QuestManager manager = questManager.GetComponent<QuestManager>();
        manager.NewQuest(id);
    }

    private void SetDialogue(){
        if (id != 0 && npcName != null) {
            SaveDialogState saveDialogState = new SaveDialogState();
            saveDialogState.SaveData(npcName, newDialogueNumber);
        }
    }
}
