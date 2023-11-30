using System.Collections.Generic;

[System.Serializable]
public class Quest {
    public int id;
    public string name;
    public string description;
    public QuestTask[] tasks;
}

[System.Serializable]
public class QuestTask {
    public int id;
    public string name;
    public string description;
}

[System.Serializable]
public class QuestList {
    public Quest[] quests;
}

[System.Serializable]
public class QuestContainer
{
    public List<Quest> quests;
}

[System.Serializable]
public class QuestData
{
    public List<ActiveQuest> activeQuests;
    public List<CompletedQuest> completedQuests;
}

[System.Serializable]
public class ActiveQuest
{
    public int id;
    public string name;
    public string description;
}

[System.Serializable]
public class CompletedQuest
{
    public int id;
    public string name;
    public string description;
}


