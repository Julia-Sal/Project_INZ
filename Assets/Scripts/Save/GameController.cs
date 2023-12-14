using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private SaveData saveData;
    private float saveInterval = 60f; // Czas w sekundach miêdzy automatycznymi zapisami
    private float timeSinceLastSave = 0f;
    public GameObject player;
    public Transform itemSlotParent;
    

    private void Start()
    {
        CheckIfFilesExist();
        saveData = new SaveData();
        saveData.LoadPosition(player);

        SaveInventory saveInventory = new SaveInventory();
        saveInventory.LoadItemData(itemSlotParent);
        
    }

    private void CheckIfFilesExist() {
        string saveInventoryFile = Application.persistentDataPath + "/SaveInventoryData.json";
        string saveDataFile = Application.persistentDataPath + "/SaveData.json";
        string saveQuestsFile = Application.persistentDataPath + "/QuestData.json";
        string saveDialogueFile = Application.persistentDataPath + "/SaveDialogue.json";

        if (!File.Exists(saveInventoryFile)) {
            SaveInventory saveInventory = new SaveInventory();
            saveInventory.CreateItemData();
        }

        if (!File.Exists(saveDataFile))
        {
            SaveData saveData = new SaveData();
            saveData.CreateData();
        }

        if (!File.Exists(saveQuestsFile))
        {
            SaveQuests saveQuests = new SaveQuests();
            saveQuests.CreateQuestData();
        }

        if (!File.Exists(saveDialogueFile)) {
            SaveDialogState saveDialogState = new SaveDialogState();
            saveDialogState.CreateData();
        }
    }

    void Update()
    {
        timeSinceLastSave += Time.deltaTime;

        if (timeSinceLastSave >= saveInterval)
        {
            saveData.SavePosition(player);
            timeSinceLastSave = 0f;
        }
    }
}
