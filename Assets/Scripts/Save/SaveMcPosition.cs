using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class SaveMcPosition
{   private string savePath;
    private PlayerPosition playerPosition;


    public void SavePosition(GameObject player) {
        savePath = Application.persistentDataPath + "/SaveData.json";
        Vector3 playerPositionVector = GetPlayerPosition(player);

        playerPosition= new PlayerPosition
            {
                playerPositionX = playerPositionVector.x,
                playerPositionY = playerPositionVector.y,
                playerPositionZ = playerPositionVector.z
        };

        string json = JsonUtility.ToJson(playerPosition);
        File.WriteAllText(savePath, json);

        Debug.Log("Game saved!");
    }

    public void LoadPosition(GameObject player) {
        savePath = Application.persistentDataPath + "/SaveData.json";
        // Sprawdü, czy istnieje plik zapisu
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            playerPosition = JsonUtility.FromJson<PlayerPosition>(json);

            SetPlayerPosition(new Vector3(playerPosition.playerPositionX, playerPosition.playerPositionY, playerPosition.playerPositionZ), player);

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
public class PlayerPosition
{
    public float playerPositionX;
    public float playerPositionY;
    public float playerPositionZ;
    // Dodaj inne potrzebne informacje o stanie gry
}