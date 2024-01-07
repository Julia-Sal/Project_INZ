using System.IO;
using UnityEngine;

public class DayAndNightController : MonoBehaviour
{
    private string controller = "DayAndNightController";
    private string saveDataPath = "/SaveData.json";

    void Start()
    {
        bool isDay = IsItDayTime();

        if (isDay)
        {
            GameObject dayAndNightControllerObject = GameObject.Find(controller);
            DayVision dayVision = dayAndNightControllerObject.GetComponent<DayVision>();
            dayVision.DayTime();
        }
        else
        {
            GameObject dayAndNightControllerObject = GameObject.Find(controller);
            NightVision nightVision = dayAndNightControllerObject.GetComponent<NightVision>();
            nightVision.NightTime();
        }
    }

    public bool IsItDayTime()
    {
        string savePath = Application.persistentDataPath + saveDataPath;

        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            SavedData savedData = JsonUtility.FromJson<SavedData>(json);
            return savedData.isDay;
        }
        else
        {
            return true;
        }
    }

    public void ChangeTime() {
        string savePath = Application.persistentDataPath + saveDataPath;

        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            SavedData savedData = JsonUtility.FromJson<SavedData>(json);

            savedData.isDay = !savedData.isDay;

            string updatedJson = JsonUtility.ToJson(savedData);
            File.WriteAllText(savePath, updatedJson);
        }
    }

    
}
