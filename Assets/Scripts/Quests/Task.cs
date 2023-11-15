using UnityEngine;

[CreateAssetMenu(fileName = "NewTask", menuName = "Task/Create New Task")]
public class Task: ScriptableObject
{
    public string taskName;
    public bool isComplete;
    public string description;


}

