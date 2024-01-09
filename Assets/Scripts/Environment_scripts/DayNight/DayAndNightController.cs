using System.IO;
using UnityEngine;
using TMPro;

public class DayAndNightController : MonoBehaviour
{
    private string saveDataPath = "/SaveData.json";

    void Start() {
        SetTime();
    }

    public void SetTime() {
        if (IsItDayTime()){
            DayVision dayVision = gameObject.GetComponent<DayVision>();
            dayVision.DayTime();
        }
        else {
            NightVision nightVision = gameObject.GetComponent<NightVision>();
            nightVision.NightTime();
        }
    }

    public bool IsItDayTime() {
        string savePath = Application.persistentDataPath + saveDataPath;

        if (File.Exists(savePath)) {
            string json = File.ReadAllText(savePath);
            SavedData savedData = JsonUtility.FromJson<SavedData>(json);
            return savedData.isDay;
        }
        else {
            return true;
        }
    }

    public void ChangeTime() {
        string savePath = Application.persistentDataPath + saveDataPath;

        if (File.Exists(savePath)) {
            string json = File.ReadAllText(savePath);
            SavedData savedData = JsonUtility.FromJson<SavedData>(json);

            savedData.isDay = !savedData.isDay;

            string updatedJson = JsonUtility.ToJson(savedData);
            File.WriteAllText(savePath, updatedJson);
        }
    }

    
}
