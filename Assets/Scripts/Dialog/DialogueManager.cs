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
    public GameObject joystick;
    
    private List<Dialog> dialogs;
    private int currentDialogIndex = 1;
    private bool optionsExist = false;
    private Animator animator;
    private bool isTextAnimating = false;
    private Coroutine textCoroutine;
    private string finalText = null;
    private int currentDialog; 

    public void Start()
    {
        dialoguePanel.SetActive(false);
    }

    public void StartDialog(string jsonPath, string npcName) {
        joystick.SetActive(false);
        LoadDialogsFromJSON(jsonPath, CheckCurrentDialogNumber(npcName));
        DisplayCurrentDialog();
        dialoguePanel.SetActive(true);
    }

    //Do dopisania
    public int CheckCurrentDialogNumber(string npcName) {
        SaveDialogState saveDialogState = new SaveDialogState();
        return saveDialogState.LoadData(npcName); 
    }

    private void LoadDialogsFromJSON(string jsonPath, int currentDialog) {
        TextAsset jsonFile = Resources.Load<TextAsset>(jsonPath);
        string jsonString = jsonFile.text;

        DialogContainer dialogContainer = JsonUtility.FromJson<DialogContainer>(jsonString);

        dialogs = dialogContainer.dialogs[currentDialog].dialogList;
    }
    
       private void DisplayCurrentDialog()
       {
           HideButtons();

           Dialog currentDialog = dialogs.Find(dialog => dialog.id == currentDialogIndex);
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
           if (dialogs.Find(dialog => dialog.id == currentDialogIndex).options != null){
               optionsExist = true;
           }
           else {
              currentDialogIndex = dialogs.Find(dialog => dialog.id == currentDialogIndex).nextDialog; 
           }
       }

       private void DisplayOptions() {
           Dialog currentDialog = dialogs.Find(dialog => dialog.id == currentDialogIndex);
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
           }
           else { 
               dialogText.text = null;
               if (currentDialogIndex == 0) { 
                   EndDialog();
               }
               else if (currentDialogIndex < dialogs.Count+1) {     
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
           DialogOption selectedOption = dialogs.Find(dialog => dialog.id == currentDialogIndex).options[optionIndex];
           currentDialogIndex = selectedOption.nextDialog;
           SelectedTextAnimation(selectedButton);
           finalText = dialogs.Find(dialog => dialog.id == currentDialogIndex).text;
           Invoke("NextPart", 0.4f);

       }

       private void SelectedTextAnimation(Button selectedButton) {
           animator = selectedButton.GetComponentInChildren<TextMeshProUGUI>().GetComponent<Animator>();
           animator.Play("enlargeText");
       }

       private void EndDialog()
       {
           joystick.SetActive(true);
           currentDialogIndex = 1;
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

       public void StartInformativeDialog(int dialogID, string jsonPath) {
           joystick.SetActive(false);
           HideButtons();
           LoadDialogsFromJSON(jsonPath, 0);

           Dialog currentDialog = dialogs.Find(dialog => dialog.id == dialogID);
           finalText = currentDialog.text;
           textCoroutine = StartCoroutine(WriteText(currentDialog.text));
           dialogSpeaker.text = currentDialog.speaker;

           CheckIfOptionsExist();
           dialoguePanel.SetActive(true);
       }
   
}

