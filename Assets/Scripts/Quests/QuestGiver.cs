using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class QuestGiver
{
    private List<Quest> quests;

    public void newQuest(int targetQuestId) {
        string jsonPath = Path.Combine(Application.dataPath, "Quests/AllQuests.json");

        if (File.Exists(jsonPath))
        {
            string json = File.ReadAllText(jsonPath);
            QuestContainer questsContainer = JsonUtility.FromJson<QuestContainer>(json);
            quests = questsContainer.quests;

            Quest targetQuest = quests.FirstOrDefault(quest => quest.id == targetQuestId); //znajdü quest o danym id

            if (targetQuest != null) {
                SaveQuests saveQuests = new SaveQuests();
                saveQuests.addQuestToActiveQuests(targetQuest);
            }
            
        }
    }

}

