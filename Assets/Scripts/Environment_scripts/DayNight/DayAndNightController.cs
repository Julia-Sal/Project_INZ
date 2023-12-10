using System.IO;
using UnityEngine;

public class DayAndNightController : MonoBehaviour
{
    private SavedData savedData;
    private string controller = "DayAndNightController";

    void Start()
    {
        bool isDay = IsItDayTime();
        Debug.Log(isDay);

        if (isDay)
        {
            Debug.Log("isDay");
            GameObject dayAndNightControllerObject = GameObject.Find(controller);
            DayVision dayVision = dayAndNightControllerObject.GetComponent<DayVision>();
            dayVision.DayTime();
        }
        else
        {
            Debug.Log("isNight");
            GameObject dayAndNightControllerObject = GameObject.Find(controller);
            NightVision nightVision = dayAndNightControllerObject.GetComponent<NightVision>();
            nightVision.NightTime();
        }
    }

    public bool IsItDayTime()
    {
        string savePath = Application.persistentDataPath + "/SaveData.json";

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
        string savePath = Application.persistentDataPath + "/SaveData.json";

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
