using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveItemsOnMap
{
    private string saveItemsPath = "/SaveItemsData.json";
    private string savePath;

    public void CreateData(Transform parent){
        savePath = Application.persistentDataPath + saveItemsPath;

        Dictionary<string, ItemData> itemDictionary = new Dictionary<string, ItemData>();

        // Iteruj po dzieciach okreœlonego rodzica
        foreach (Transform child in parent)
        {
            // Pobierz nazwê i pozycjê ka¿dego dziecka
            string itemName = child.name;
            float posX = child.position.x;
            float posY = child.position.y;
            float posZ = child.position.z;
            bool isActive = child.gameObject.activeSelf;
            // Dodaj dane do s³ownika
            itemDictionary[itemName] = new ItemData
            {
                name = itemName,
                positionX = posX,
                positionY = posY,
                positionZ = posZ,
                isActive = isActive
            };
        }

        // Twórz listê i zapisz do pliku JSON
        ItemDataList itemDataList = new ItemDataList
        {
            data = new List<ItemData>(itemDictionary.Values)
        };

        string jsonString = JsonUtility.ToJson(itemDataList, true);
        File.WriteAllText(savePath, jsonString);
    }

    public void LoadData(Transform parent) {
        savePath = Application.persistentDataPath + saveItemsPath;

        if (File.Exists(savePath))
        {
            string jsonString = File.ReadAllText(savePath);
            ItemDataList itemDataList = JsonUtility.FromJson<ItemDataList>(jsonString);

            foreach (ItemData itemData in itemDataList.data)
            {
                Transform child = parent.Find(itemData.name);

                if (child != null)
                {
                    child.position = new Vector3(itemData.positionX, itemData.positionY, itemData.positionZ);
                    child.gameObject.SetActive(itemData.isActive);
                }
                else
                {
                    Debug.LogWarning($"Nie znaleziono obiektu o nazwie {itemData.name} w hierarchii transformacji.");
                }
            }
        }
        else
        {
            Debug.LogWarning("Plik z danymi nie istnieje.");
        }
    }

    public void UpdateData(Transform parent) {
        savePath = Application.persistentDataPath + saveItemsPath;

        if (File.Exists(savePath)) {
            string jsonString = File.ReadAllText(savePath);
            ItemDataList itemDataList = JsonUtility.FromJson<ItemDataList>(jsonString);

            foreach (ItemData itemData in itemDataList.data) {
                Transform child = parent.Find(itemData.name);

                if (child != null) {
                    child.position = new Vector3(itemData.positionX, itemData.positionY, itemData.positionZ);
                    child.gameObject.SetActive(itemData.isActive);
                }
                else {
                    Debug.LogWarning($"Nie znaleziono obiektu o nazwie {itemData.name} w hierarchii transformacji.");
                }
            }
        }
        else
        {
            Debug.LogWarning("Plik z danymi nie istnieje.");
        }
    }

    public void SaveData(Transform parent)
    {
        savePath = Application.persistentDataPath + saveItemsPath;

        List<ItemData> itemList = new List<ItemData>();

        foreach (Transform child in parent)
        {
            string itemName = child.name;
            float posX = child.position.x;
            float posY = child.position.y;
            float posZ = child.position.z;
            bool isActive = child.gameObject.activeSelf;

            itemList.Add(new ItemData
            {
                name = itemName,
                positionX = posX,
                positionY = posY,
                positionZ = posZ,
                isActive = isActive
            });;
        }

        ItemDataList itemDataList = new ItemDataList
        {
            data = itemList
        };

        string jsonString = JsonUtility.ToJson(itemDataList, true);
        File.WriteAllText(savePath, jsonString);
    }
}

[System.Serializable]
public class ItemData
{
    public string name;
    public float positionX;
    public float positionY;
    public float positionZ;
    public bool isActive;
}

[System.Serializable]
public class ItemDataList
{
    public List<ItemData> data;
}
