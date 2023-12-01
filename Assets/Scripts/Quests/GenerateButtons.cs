using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GenerateButtons : MonoBehaviour
{
    public GameObject buttonPrefab; // Przycisk prefabrykowany do generowania
    public Transform panel;
    public Transform descriptionPanel;
    public GameObject descriptionPrefab;

    public void Generate() {
        SaveQuests saveQuests = new SaveQuests();
        List<ActiveQuest> activeQuests = saveQuests.LoadActiveQuests();

        for (int i = 0; i < activeQuests.Count; i++)
        {
            GameObject buttonInstance = Instantiate(buttonPrefab, panel);

            TextMeshProUGUI buttonText = buttonInstance.GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = activeQuests[i].name;

            ActiveQuest currentQuest = activeQuests[i];
            
            Button currentButton = buttonInstance.GetComponent<Button>();

            currentButton.onClick.RemoveAllListeners();
            currentButton.onClick.AddListener(() => ResetDescription());
            currentButton.onClick.AddListener(() => ResetButtons());
            currentButton.onClick.AddListener(() => AnimateButton(currentButton));
            currentButton.onClick.AddListener(() => ShowDescription(currentQuest));
        }

    }

    public void ShowDescription(ActiveQuest quest)
    {
        GameObject descriptionInstance = Instantiate(descriptionPrefab, descriptionPanel);
        TMP_Text textComponent = descriptionInstance.GetComponent<TMP_Text>();
        textComponent.text = quest.description;
        //descriptionPrefab.SetActive(true);
    }

    public void ResetDescription() {
        foreach (Transform child in descriptionPanel)
        {
            Destroy(child.gameObject);
        }

    }

    public void DestroyButtons() {
        Button[] buttons = panel.GetComponentsInChildren<Button>();
        foreach (Button button in buttons) {
            Destroy(button.gameObject);
        }
    }

    private Animator animator;
    private void AnimateButton(Button selectedButton) {
        animator = selectedButton.GetComponentInChildren<TextMeshProUGUI>().GetComponent<Animator>();
        animator.Play("enlargeText");
    }

    private void ResetButtons() {
        Button[] buttons = panel.GetComponentsInChildren<Button>();
        foreach (Button button in buttons)
        {
            button.GetComponentInChildren<TextMeshProUGUI>().GetComponent<Animator>().Play("default");
        }
    }

    public void setAllDecsriptionsAsFalse() { 
        
    }
    
}
