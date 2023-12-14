using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveDialogState
{
    private string savePath;
    private string saveDialoguePath = "/SaveDialogue.json";


    public void CreateData()
    {
        savePath = Application.persistentDataPath + saveDialoguePath;
        List<DialogData> dialogList = new List<DialogData>();

        dialogList.Add(new DialogData { npcName = "chief", dialogNumber = 0 });
        dialogList.Add(new DialogData { npcName = "cook", dialogNumber = 0 });

        DialogDataList dialogDataList = new DialogDataList {
            data = dialogList
        };

        string jsonString = JsonUtility.ToJson(dialogDataList, true);
        File.WriteAllText(savePath, jsonString);
    }

    public int LoadData(string npcName) { 
        savePath = Application.persistentDataPath + saveDialoguePath;
        string jsonString = File.ReadAllText(savePath);

        DialogDataList dialogDataList = JsonUtility.FromJson<DialogDataList>(jsonString);
        DialogData foundDialog = dialogDataList.data.Find(dialog => dialog.npcName == npcName);

        return foundDialog.dialogNumber;
    }

    public void SaveData(string npcName, int newDialogNumber) { 
        savePath = Application.persistentDataPath + saveDialoguePath;
        string jsonString = File.ReadAllText(savePath);

        DialogDataList dialogDataList = JsonUtility.FromJson<DialogDataList>(jsonString);
        DialogData foundDialog = dialogDataList.data.Find(dialog => dialog.npcName == npcName);
        foundDialog.dialogNumber = newDialogNumber;

        string newJsonString = JsonUtility.ToJson(dialogDataList, true);

        File.WriteAllText(savePath, newJsonString);

    }


}

[System.Serializable]
public class DialogData {
    public string npcName;
    public int dialogNumber;
}

[System.Serializable]
public class DialogDataList {
    public List<DialogData> data;
}
