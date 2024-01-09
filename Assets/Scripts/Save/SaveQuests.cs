using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System.Linq;

[System.Serializable]
public class SaveQuests
{
    private string savePath;
    private string path = "/QuestData.json";

    public void CreateQuestData() {
        savePath = Application.persistentDataPath + path;

        if (!File.Exists(savePath)) {
            QuestData questData = new QuestData();
            string json = JsonUtility.ToJson(questData);
            File.WriteAllText(savePath, json);
        }
    }

    public void AddQuestToActiveQuests(Quest targetQuest) {
        savePath = Application.persistentDataPath + path;

        if (File.Exists(savePath)) {
            string json = File.ReadAllText(savePath);
            QuestData questData = JsonUtility.FromJson<QuestData>(json);

            if (!questData.activeQuests.Any(quest => quest.id == targetQuest.id)) {
                questData.activeQuests.Add(new ActiveQuest
                {
                    id = targetQuest.id,
                    name = targetQuest.name,
                    description = targetQuest.description
                });
            
                string updatedJson = JsonUtility.ToJson(questData, true);
                File.WriteAllText(savePath, updatedJson);

                Debug.Log("Dodano do activeQuests");

                //poka¿ alert
                GameObject questManager = GameObject.Find("QuestManager");
                questManager.GetComponent<QuestManager>().ShowQuestAlert("Nowe Zadanie!");

            }
            else {
                Debug.Log("ju¿ istnieje na liœcie activeQuests");
            }
        }
        else
        {
            Debug.Log("œcie¿ka nie istnieje");
        }
    }

    public void AddQuestToCompletedQuests(Quest targetQuest) {
        savePath = Application.persistentDataPath + path;

        if (File.Exists(savePath)) {
            string json = File.ReadAllText(savePath);
            QuestData questData = JsonUtility.FromJson<QuestData>(json);

            if (!questData.completedQuests.Any(quest => quest.id == targetQuest.id)) {
                questData.completedQuests.Add(new CompletedQuest
                {
                    id = targetQuest.id,
                    name = targetQuest.name,
                    description = targetQuest.description
                });

                string updatedJson = JsonUtility.ToJson(questData, true);
                File.WriteAllText(savePath, updatedJson);

                Debug.Log($"Dodano do completedQuests");

                //poka¿ alert
                GameObject questManager = GameObject.Find("QuestManager");
                questManager.GetComponent<QuestManager>().ShowQuestAlert("Ukoñczono Zadanie!");
            }
            else
            {
                Debug.Log("ju¿ istnieje na liœcie completedQuests");
            }
        }
        else
        {
            Debug.Log("Plik JSON nie istnieje na");
        }
    }

    public List<CompletedQuest> LoadCompletedQuests() {
        savePath = Application.persistentDataPath + path;

        string json = File.ReadAllText(savePath);
        QuestData questData = JsonUtility.FromJson<QuestData>(json);
        List<CompletedQuest> completedQuests = questData.completedQuests;
        return completedQuests;
    }

    public List<ActiveQuest> LoadActiveQuests() {
        savePath = Application.persistentDataPath + path;

        string json = File.ReadAllText(savePath);
        QuestData questData = JsonUtility.FromJson<QuestData>(json);
        List<ActiveQuest> activeQuests = questData.activeQuests;
        return activeQuests;
        
    }
}
