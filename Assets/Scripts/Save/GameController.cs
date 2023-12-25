using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private float saveInterval = 60f; // Czas w sekundach miêdzy automatycznymi zapisami
    private float timeSinceLastSave = 0f;
    public GameObject player;
    public Transform itemSlotParent;
    public Transform itemParent;
    

    private void Start(){
        CheckIfFilesExist();
        LoadAll();
    }

    private void CheckIfFilesExist() {
        string saveInventoryFile = Application.persistentDataPath + "/SaveInventoryData.json";
        string saveDataFile = Application.persistentDataPath + "/SaveData.json";
        string saveQuestsFile = Application.persistentDataPath + "/QuestData.json";
        string saveDialogueFile = Application.persistentDataPath + "/SaveDialogue.json";
        string saveItemsFile = Application.persistentDataPath + "/SaveItemsData.json";

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

        if (!File.Exists(saveItemsFile))
        {
            SaveItemsOnMap saveItems = new SaveItemsOnMap();
            saveItems.CreateData(itemParent);
        }
    }

    void OnApplicationQuit(){
        CheckIfFilesExist();
        SaveAll();
    }

    public void SaveAll() { 
        SaveData saveData = new SaveData();
        saveData.SavePosition(player);

        SaveItemsOnMap saveItems = new SaveItemsOnMap();
        saveItems.SaveData(itemParent);
    }
    private void LoadAll() { 
        SaveData saveData = new SaveData();
        saveData.LoadPosition(player);

        SaveInventory saveInventory = new SaveInventory();
        saveInventory.LoadItemData(itemSlotParent);

        SaveItemsOnMap saveItems = new SaveItemsOnMap();
        saveItems.LoadData(itemParent);
    }

    void Update(){
        timeSinceLastSave += Time.deltaTime;

        if (timeSinceLastSave >= saveInterval)
        {
            CheckIfFilesExist();
            SaveAll();
            timeSinceLastSave = 0f;
        }
    }
}
