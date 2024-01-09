using System.Collections.Generic;
using System.IO;
using System.Linq;
using TMPro;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    private List<ActiveQuest> activeQuests = new List<ActiveQuest>();
    private List<CompletedQuest> completedQuests = new List<CompletedQuest>();
    private List<Quest> quests;
    public GameObject questAlert;
    public QuestData questData;
    public GameObject questsParent;
    private SaveQuests saveQuests;

    void Start() {
        Invoke("SetQuests", 2f);
        Invoke("SetTriggers", 2f);
    }

    public void SetQuests() {
        SaveQuests saveQuests = new SaveQuests();
        activeQuests = saveQuests.LoadActiveQuests();

        foreach (Transform questObject in questsParent.transform)
        {
            string questObjectName = questObject.name;
            if (activeQuests.Any(quest => quest.id.ToString() == questObjectName)) {
                questObject.gameObject.SetActive(true);
            }
        }
    }

    public void SetTriggers() {
        SaveQuests saveQuests = new SaveQuests();
        completedQuests = saveQuests.LoadCompletedQuests();
        activeQuests = saveQuests.LoadActiveQuests();

        foreach (Transform questObject in questsParent.transform)
        {
            string questObjectName = questObject.name;

            if (questObjectName.StartsWith("StartQuestTrigger") && int.TryParse(questObjectName.Substring("StartQuestTrigger".Length), out int questNumber))
            {
                if (completedQuests.Any(quest => quest.id == questNumber))
                {
                    questObject.gameObject.SetActive(false);
                }

                if (activeQuests.Any(quest => quest.id == questNumber))
                {
                    questObject.gameObject.SetActive(false);
                }
            }
        }
    }


    public void EndQuest(int targetQuestId) {
        RemoveQuestFromActiveById(targetQuestId);

        TextAsset jsonFile = Resources.Load<TextAsset>("Quests/AllQuests");
        string json = jsonFile.text;
        if (json != null)
        {
            QuestContainer questsContainer = JsonUtility.FromJson<QuestContainer>(json);
            quests = questsContainer.quests;

            Quest targetQuest = quests.FirstOrDefault(quest => quest.id == targetQuestId);

            if (targetQuest != null)
            {
                SaveQuests saveQuests = new SaveQuests();
                saveQuests.AddQuestToCompletedQuests(targetQuest);
            }

        }

        SetQuests();
        SetTriggers();
    }

    public void RemoveQuestFromActiveById(int questId)
    {
        string savePath = Application.persistentDataPath + "/QuestData.json";

        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            QuestData questData = JsonUtility.FromJson<QuestData>(json);

            Debug.Log(questData.activeQuests.Any(quest => quest.id == questId));
            if (questData.activeQuests.Any(quest => quest.id == questId))
            {
                ActiveQuest questToRemove = questData.activeQuests.Find(quest => quest.id == questId);
                questData.activeQuests.Remove(questToRemove);

                string updatedJson = JsonUtility.ToJson(questData, true);
                File.WriteAllText(savePath, updatedJson);

                Debug.Log($"Usuniêto z activeQuests");

            }
            else
            {
                Debug.Log("Nie istnieje na liœcie activeQuests");
            }
        }
        else
        {
            Debug.Log("Plik JSON nie istnieje");
        }
    }


    public void ShowQuestAlert(string alert) {
        TextMeshProUGUI buttonTextTMP = questAlert.GetComponentInChildren<TextMeshProUGUI>();
        buttonTextTMP.text = alert;
        questAlert.SetActive(true);

    }

    public void NewQuest(int targetQuestId)
    {
        TextAsset jsonFile = Resources.Load<TextAsset>("Quests/AllQuests");
        string json = jsonFile.text;
        if (json!=null)
        {
            QuestContainer questsContainer = JsonUtility.FromJson<QuestContainer>(json);
            quests = questsContainer.quests;

            Quest targetQuest = quests.FirstOrDefault(quest => quest.id == targetQuestId);

            if (targetQuest != null)
            {
                SaveQuests saveQuests = new SaveQuests();
                saveQuests.AddQuestToActiveQuests(targetQuest);
            }

        }

        SetQuests();
        SetTriggers();
    }

}
