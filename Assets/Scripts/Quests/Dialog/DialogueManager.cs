using UnityEngine;
using TMPro;
using System.Collections.Generic;
using UnityEngine.UI;
using System.IO;


public class DialogueManager : MonoBehaviour
{
    public TMP_Text dialogText;
    public TMP_Text dialogSpeaker;
    public Button[] optionButtons;
    public GameObject dialoguePanel;
    private List<Dialog> dialogs;
    private int currentDialogIndex = 0;
    private bool optionsExist = false;

    public void Start()
    {
        dialoguePanel.SetActive(false);
    }

    public void StartDialog(string jsonPath)
    {
        LoadDialogsFromJSON(jsonPath);
        DisplayCurrentDialog();
        dialoguePanel.SetActive(true);
    }

    private void LoadDialogsFromJSON(string jsonPath)
    {
        string jsonString = File.ReadAllText(jsonPath);
        DialogContainer dialogContainer = JsonUtility.FromJson<DialogContainer>(jsonString);
        dialogs = dialogContainer.dialogs;
    }

    private void DisplayCurrentDialog()
    {
        HideButtons();
        
        Dialog currentDialog = dialogs[currentDialogIndex];
        dialogText.text = currentDialog.text;
        dialogSpeaker.text = currentDialog.speaker;

        CheckIfOptionsExist();
    }

    private void HideButtons() { 
        foreach (var button in optionButtons){
            button.gameObject.SetActive(false);
        }
    }

    private void CheckIfOptionsExist() { 
        if (dialogs[currentDialogIndex].options != null){
            optionsExist = true;
        }
        else {
           currentDialogIndex = dialogs[currentDialogIndex].nextDialog;
        }
    }

    private void DisplayOptions() {
        Dialog currentDialog = dialogs[currentDialogIndex];
        dialogText.text = null;
        dialogSpeaker.text = "Me";

        for (int i = 0; i < optionButtons.Length; i++)
        {
            if (i < currentDialog.options.Length)
            {
                optionButtons[i].gameObject.SetActive(true);
                optionButtons[i].GetComponentInChildren<Text>().text = "- "+ currentDialog.options[i].text;
                int optionIndex = i; 
                optionButtons[i].onClick.RemoveAllListeners();
                optionsExist = false;
                optionButtons[i].onClick.AddListener(() => OnOptionSelected(optionIndex));
            }
            else
            {
                optionButtons[i].gameObject.SetActive(false);
            }
        }
    }

    public void NextPart() {
        if (currentDialogIndex < dialogs.Count) {
            if (optionsExist) {
                DisplayOptions();
            }
            else {
                DisplayCurrentDialog(); 
            }
        }
        else {
            EndDialog();
        }
    }

    private void OnOptionSelected(int optionIndex)
    {
        DialogOption selectedOption = dialogs[currentDialogIndex].options[optionIndex];
        currentDialogIndex = selectedOption.nextDialog;
        NextPart();
    }

    private void EndDialog()
    {
        currentDialogIndex = 0;
        dialoguePanel.SetActive(false);
    }
}





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
