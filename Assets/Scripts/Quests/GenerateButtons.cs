using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GenerateButtons : MonoBehaviour
{
    public GameObject buttonPrefab; // Przycisk prefabrykowany do generowania
    public Transform panel;

    public void generate() {
        SaveQuests saveQuests = new SaveQuests();
        List<ActiveQuest> activeQuests = saveQuests.LoadActiveQuests();
        foreach (var quest in activeQuests)
        {
            GameObject buttonInstance = Instantiate(buttonPrefab, panel);

            // Pobierz komponent TextMeshProUGUI z instancji przycisku
            TextMeshProUGUI buttonText = buttonInstance.GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = quest.name;
        }

    }


    
}
