using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private SaveMcPosition saveMcPosition;
    private float saveInterval = 60f; // Czas w sekundach miêdzy automatycznymi zapisami
    private float timeSinceLastSave = 0f;
    public GameObject player;
    public Transform itemSlotParent;
    

    private void Start()
    {
        CheckIfFilesExist();
        saveMcPosition = new SaveMcPosition();
        saveMcPosition.LoadPosition(player);

        SaveInventory saveInventory = new SaveInventory();
        saveInventory.LoadItemData(itemSlotParent);
        
    }

    private void CheckIfFilesExist() {
        string saveInventoryFile = Application.persistentDataPath + "/SaveInventoryData.json";
        string saveMcPositionFile = Application.persistentDataPath + "/SaveData.json";
        string saveQuestsFile = Application.persistentDataPath + "/QuestData.json";

        if (!File.Exists(saveInventoryFile)) {
            SaveInventory saveInventory = new SaveInventory();
            saveInventory.CreateItemData();
        }

        if (!File.Exists(saveMcPositionFile))
        {
            File.Create(saveMcPositionFile).Close();
        }

        if (!File.Exists(saveQuestsFile))
        {
            SaveQuests saveQuests = new SaveQuests();
            saveQuests.CreateQuestData();
        }
    }

    void Update()
    {
        timeSinceLastSave += Time.deltaTime;

        if (timeSinceLastSave >= saveInterval)
        {
            saveMcPosition.SavePosition(player);
            timeSinceLastSave = 0f;
        }
    }
}
