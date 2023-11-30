using UnityEngine;

public class StartQuest : MonoBehaviour
{
    public int id;
    private void OnTriggerEnter(Collider other)
    {
        QuestGiver questGiver = new QuestGiver();
        questGiver.newQuest(id);
    }
}
