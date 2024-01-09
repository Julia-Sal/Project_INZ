using UnityEngine;

public class StartQuest : MonoBehaviour
{
    public int id;
    public GameObject questManager;

    private void OnTriggerEnter(Collider other) {
        StartQuestNormal();
    }

    public void StartQuestAfterDialogue() {

    }

    private void OnMouseDown() {
        StartQuestNormal();
    }

    public void StartQuestNormal() {
        QuestManager manager = questManager.GetComponent<QuestManager>();
        manager.NewQuest(id);
        manager.SetQuests();
    }

}
