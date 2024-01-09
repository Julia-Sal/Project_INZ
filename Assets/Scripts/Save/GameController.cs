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
    public GameObject musicController;
    public GameObject menuPanel;
    public DayVision dayAndNightController;

    private string saveInventoryFile;
    private string saveDataFile;
    private string saveQuestsFile;
    private string saveDialogueFile;
    private string saveItemsFile;



    void Start(){
        menuPanel.SetActive(true);

        if (!CheckIfFilesExist()) {
            menuPanel.transform.Find("Instruction").gameObject.SetActive(true);
            CreateAllFiles();
            LoadAll();

            //dayAndNightController.DayTime();
        }
        else {
            LoadAll();
        }
    }

    public bool CheckIfFilesExist() {
        saveInventoryFile = Application.persistentDataPath + "/SaveInventoryData.json";
        saveDataFile = Application.persistentDataPath + "/SaveData.json";
        saveQuestsFile = Application.persistentDataPath + "/QuestData.json";
        saveDialogueFile = Application.persistentDataPath + "/SaveDialogue.json";
        saveItemsFile = Application.persistentDataPath + "/SaveItemsData.json";

        if (!File.Exists(saveDataFile) && !File.Exists(saveInventoryFile) && !File.Exists(saveQuestsFile) && !File.Exists(saveDialogueFile) && !File.Exists(saveItemsFile)) {
            return false;
        }
        else {
            return true;
        }
    }

    public void CreateAllFiles() { 

        SaveData saveData = new SaveData();
        saveData.CreateData();

        SaveInventory saveInventory = new SaveInventory();
        saveInventory.CreateItemData();

        SaveQuests saveQuests = new SaveQuests();
        saveQuests.CreateQuestData();

        SaveDialogState saveDialogState = new SaveDialogState();
        saveDialogState.CreateData();

        SaveItemsOnMap saveItems = new SaveItemsOnMap();
        saveItems.CreateData(itemParent);
    }


    void OnApplicationQuit(){
        if (!CheckIfFilesExist()) {
            CreateAllFiles();
        }
        else { 
            SaveAll();
        }
        
    }

    public void SaveAll() { 
        SaveData saveData = new SaveData();
        saveData.SaveAllData(player);

        SaveItemsOnMap saveItems = new SaveItemsOnMap();
        saveItems.SaveData(itemParent);
    }

    public void LoadAll() { 
        SaveData saveData = new SaveData();
        saveData.LoadData(player);

        SaveInventory saveInventory = new SaveInventory();
        saveInventory.LoadItemData(itemSlotParent);

        SaveItemsOnMap saveItems = new SaveItemsOnMap();
        saveItems.LoadData(itemParent);
    }

    void Update(){
        timeSinceLastSave += Time.deltaTime;

        if (timeSinceLastSave >= saveInterval) {
            SaveAll();
            timeSinceLastSave = 0f;
        }
    }

    public void PauseGame() {
        musicController.GetComponent<AudioSource>().Pause();
    }

    public void ResumeGame() {
        musicController.GetComponent<AudioSource>().UnPause();
    }

}
