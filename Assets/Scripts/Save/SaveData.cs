using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class SaveData
{   private string savePath;
    private SavedData savedData;
    private string saveDataPath = "/SaveData.json";

    public void CreateData() {
        savePath = Application.persistentDataPath + saveDataPath;
        savedData = new SavedData
        {
            playerPositionX = -14.8f,
            playerPositionY = 0.03f,
            playerPositionZ = 42.5f,
            isDay = true
        };

        string json = JsonUtility.ToJson(savedData, true);
        File.WriteAllText(savePath, json);
    }

    public void SaveAllData(GameObject player)
    {
        savePath = Application.persistentDataPath + saveDataPath;
        Vector3 playerPositionVector = GetPlayerPosition(player);
        string jsonToRead = File.ReadAllText(savePath);
        savedData = JsonUtility.FromJson<SavedData>(jsonToRead);

        savedData = new SavedData
        {
            playerPositionX = playerPositionVector.x,
            playerPositionY = playerPositionVector.y,
            playerPositionZ = playerPositionVector.z,
            isDay = savedData.isDay
        };

        string json = JsonUtility.ToJson(savedData, true);
        File.WriteAllText(savePath, json);

        Debug.Log("Game saved!");
    }

    public void LoadData(GameObject player) {
        savePath = Application.persistentDataPath + saveDataPath;
        
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            savedData = JsonUtility.FromJson<SavedData>(json);

            Debug.Log(savedData.playerPositionX + savedData.playerPositionY + savedData.playerPositionZ);
            SetPlayerPosition(new Vector3(savedData.playerPositionX, savedData.playerPositionY, savedData.playerPositionZ), player);

            Debug.Log("Game loaded!");
        }
        else
        {
            Debug.LogWarning("No saved game found.");
        }
    }



    private Vector3 GetPlayerPosition(GameObject player)
    {
        return player.transform.position;
    }
    private void SetPlayerPosition(Vector3 position, GameObject player)
    {
        player.transform.position = position;
    }
}

[System.Serializable]
public class SavedData
{
    public float playerPositionX;
    public float playerPositionY;
    public float playerPositionZ;
    public bool isDay;
}