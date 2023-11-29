using UnityEngine;
using TMPro;
using System.Collections.Generic;
using UnityEngine.UI;
using System.IO;
using System.Collections;

public class DialogueManager : MonoBehaviour
{
    public TMP_Text dialogText;
    public TMP_Text dialogSpeaker;
    public Button[] optionButtons;
    public GameObject dialoguePanel;
    private List<Dialog> dialogs;
    private int currentDialogIndex = 0;
    private bool optionsExist = false;
    private Animator animator;
    private bool isTextAnimating = false;
    private Coroutine textCoroutine;
    private string finalText = null;

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
        finalText = currentDialog.text;
        textCoroutine = StartCoroutine(WriteText(currentDialog.text));
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
        dialogSpeaker.text = "Me";

        for (int i = 0; i < optionButtons.Length; i++)
        {
            optionButtons[i].gameObject.SetActive(true);
            optionButtons[i].GetComponentInChildren<TMP_Text>().text = "- "+ currentDialog.options[i].text;
            int optionIndex = i;
            Button currentButton = optionButtons[i];
            optionButtons[i].onClick.RemoveAllListeners();
            optionsExist = false;
            optionButtons[i].onClick.AddListener(() => OnOptionSelected(optionIndex, currentButton));
        }
    }

    public void NextPart() {
        
        if (isTextAnimating) {
            StopCoroutine(textCoroutine);
            isTextAnimating = false;
            dialogText.text = finalText;

            Debug.Log("AMA");
        }
        else { 
            dialogText.text = null;

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
    }

    private void OnOptionSelected(int optionIndex, Button selectedButton)  {
        DialogOption selectedOption = dialogs[currentDialogIndex].options[optionIndex];
        currentDialogIndex = selectedOption.nextDialog;
        SelectedTextAnimation(selectedButton);
        finalText = dialogs[selectedOption.nextDialog].text;
        Invoke("NextPart", 0.5f);
    }

    private void SelectedTextAnimation(Button selectedButton) {
        animator = selectedButton.GetComponentInChildren<TextMeshProUGUI>().GetComponent<Animator>();
        animator.Play("enlargeText");
    }

    private void EndDialog()
    {
        currentDialogIndex = 0;
        dialoguePanel.SetActive(false);
    }


    public float delayBetweenLetters = 0.05f;
    public IEnumerator WriteText(string text)
    {
        isTextAnimating = true;
        string fullText = text;
        text = "";

        for (int i = 0; i < fullText.Length; i++)
        {
            dialogText.text += fullText[i];
            yield return new WaitForSeconds(delayBetweenLetters);
        }
        isTextAnimating = false;
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
