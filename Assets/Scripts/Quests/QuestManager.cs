using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public static QuestManager instance;
    public List<Quest> activeQuests = new List<Quest>();
    public List<Quest> completedQuests = new List<Quest>();

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



}
