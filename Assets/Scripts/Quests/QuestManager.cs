using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public static QuestManager instance;
    private List<Quest> activeQuests = new List<Quest>();
    private List<Quest> completedQuests = new List<Quest>();
    private List<Quest> quests;
    public GameObject questAlert;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Opcjonalnie, jeœli chcesz, aby obiekt przetrwa³ zmiany scen

        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        //SaveQuests saveQuests = new SaveQuests();
        
        //activeQuests =  saveQuests.LoadActiveQuests();
        // completedQuests = saveQuests.LoadCompletedQuests();

    }

    private bool CheckConditions()
    {
        /*
        foreach (var task in tasks)
        {
            if (!task.isComplete)
            {
                Debug.Log("task is not complete!");
                return false;
            }
        }
        Debug.Log("task is complete!");*/
        return true;
    }

    public void endQuestIfPossible()
    {
        /*
        if (CheckConditions())
        {
            isActive = false;
            isComplete = true;

            completedQuests.Add(this);
            activeQuests.Remove(this);


        }*/
    }

    public void ShowQuestAlert()
    {
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
    }

}
