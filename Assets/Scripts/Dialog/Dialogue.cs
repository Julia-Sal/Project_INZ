using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogContainer
{
    public List<Dialog> dialogs;
}

[System.Serializable]
public class Dialog
{
    public int id;
    public string speaker;
    public string text;
    public bool canShow;
    public DialogOption[] options;
    public int nextDialog;
}

[System.Serializable]
public class DialogOption
{
    public int id;
    public string text;
    public int nextDialog;
}

[System.Serializable]
public class Dialogue
{
    public DialogueLine[] lines;
}

[System.Serializable]
public class DialogueLine
{
    public string speaker;
    public string text;
}

[System.Serializable]
public class InformativeDialogueLines
{
    public DialogueLine[] lines;
}



