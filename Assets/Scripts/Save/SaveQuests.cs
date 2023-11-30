using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System.Linq;

[System.Serializable]
public class SaveQuests
{
    private string savePath = Application.persistentDataPath + "/QuestData.json";

    private void CheckIfFileExist()
    {
        if (!File.Exists(savePath))
        {
            File.Create(savePath).Close(); ;
        }
    }

    public void addQuestToActiveQuests(Quest targetQuest) {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            QuestData questData = JsonUtility.FromJson<QuestData>(json);

            Debug.Log(!questData.activeQuests.Any(quest => quest.id == targetQuest.id));
            if (!questData.activeQuests.Any(quest => quest.id == targetQuest.id))
            {
                questData.activeQuests.Add(new ActiveQuest
                {
                    id = targetQuest.id,
                    name = targetQuest.name,
                    description = targetQuest.description
                });
            
                string updatedJson = JsonUtility.ToJson(questData, true);
                File.WriteAllText(savePath, updatedJson);

                Debug.Log($"Dodano do activeQuests");
            }
            else
            {
                Debug.Log("ju� istnieje na li�cie activeQuests");
            }
        }
        else
        {
            Debug.Log("Plik JSON nie istnieje na");
        }
    }

    public void addQuestToCompletedQuests(Quest targetQuest) {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            QuestData questData = JsonUtility.FromJson<QuestData>(json);

            Debug.Log(!questData.completedQuests.Any(quest => quest.id == targetQuest.id));
            if (!questData.completedQuests.Any(quest => quest.id == targetQuest.id))
            {
                questData.completedQuests.Add(new CompletedQuest
                {
                    id = targetQuest.id,
                    name = targetQuest.name,
                    description = targetQuest.description
                });

                string updatedJson = JsonUtility.ToJson(questData, true);
                File.WriteAllText(savePath, updatedJson);

                Debug.Log($"Dodano do completedQuests");
            }
            else
            {
                Debug.Log("ju� istnieje na li�cie completedQuests");
            }
        }
        else
        {
            Debug.Log("Plik JSON nie istnieje na");
        }
    }

    public void LoadCompletedQuests() {
    }


    public List<ActiveQuest> LoadActiveQuests() {
        CheckIfFileExist();
        string json = File.ReadAllText(savePath);
        QuestData questData = JsonUtility.FromJson<QuestData>(json);
        List<ActiveQuest> activeQuests = questData.activeQuests;
        return activeQuests;
        
    }
}