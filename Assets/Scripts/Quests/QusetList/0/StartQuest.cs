using UnityEngine;

public class StartQuest : MonoBehaviour
{
    public int id;
    public int newDialogueNumber;
    public string npcName;

    private void OnTriggerEnter(Collider other)
    {
        QuestGiver questGiver = new QuestGiver();
        questGiver.newQuest(id);

        SaveDialogState saveDialogState = new SaveDialogState();
        saveDialogState.SaveData(npcName, newDialogueNumber);
        
    }
}
