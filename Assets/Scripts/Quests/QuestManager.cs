using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public static QuestManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Opcjonalnie, je�li chcesz, aby obiekt przetrwa� zmiany scen

        }
        else
        {
            Destroy(gameObject);
        }
    } 
    
    public HashSet<Quest> activeQuests = new HashSet<Quest>();
    public HashSet<Quest> completedQuests = new HashSet<Quest>();

}
