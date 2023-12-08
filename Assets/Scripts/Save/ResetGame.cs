using UnityEngine;
using System.IO;

public class ResetGame : MonoBehaviour
{
    private GameObject player;

    public void StartNewGame() {
        player = GameObject.Find("MainCharacter");
        ResetPlayerPosition();
        ResetQuests();
    }

    public void ResetPlayerPosition() {
        player.transform.position = new Vector3(-21.2f, 0.1f, 42.1f);
    }

    public void ResetQuests() {
        string savePath = Application.persistentDataPath + "/QuestData.json";

        if (File.Exists(savePath))
        {
            File.Delete(savePath);
            Debug.Log("Plik JSON zosta³ wyczyszczony.");
        }

        QuestData emptyData = new QuestData();
        string jsonData = JsonUtility.ToJson(emptyData);
        File.WriteAllText(savePath, jsonData);
    }

    public void ResetDialogues() { 
    
    }
}
