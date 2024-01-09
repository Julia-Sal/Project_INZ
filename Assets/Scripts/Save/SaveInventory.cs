using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class SaveInventory: MonoBehaviour {
    private string savePath = Application.persistentDataPath + "/SaveInventoryData.json";
    public void SaveItemData(string name, int slotIndex) {
        
        string json = File.ReadAllText(savePath);
        SlotsContainer container = JsonUtility.FromJson<SlotsContainer>(json);

        ItemSlot objectToEdit = container.itemSlots.Find(obj => obj.id == slotIndex);
        if (objectToEdit != null) {
            objectToEdit.name = name;
            objectToEdit.isEmpty = false;
        }
        else {
            Debug.LogWarning("Slot with ID " + slotIndex + " not found.");
        }

        string updatedJson = JsonUtility.ToJson(container, true);
        File.WriteAllText(savePath, updatedJson);
    }


    public void LoadItemData(Transform itemSlotParent) {
        string json = File.ReadAllText(savePath);
        SlotsContainer container = JsonUtility.FromJson<SlotsContainer>(json);

        for (int i = 0; i < container.itemSlots.Count && i < 5; i++)
        {
            ItemSlot obj = container.itemSlots[i];
            if (obj.name != null && obj.name != "") {
                Button itemSlotButton = itemSlotParent.GetChild(i).GetComponent<Button>();
                InventoryController inventoryController = itemSlotButton.GetComponent<InventoryController>();
                inventoryController.itemInInventory = LoadItemPrefabByName(obj.name);
                SpriteRenderer itemSpriteRenderer = inventoryController.itemInInventory.GetComponent<SpriteRenderer>();
                Image imageComponent = itemSlotButton.transform.GetChild(1).GetComponent<Image>();
                imageComponent.sprite = itemSpriteRenderer.sprite;
            }
            else {
                Button itemSlotButton = itemSlotParent.GetChild(i).GetComponent<Button>();
                Image imageComponent = itemSlotButton.transform.GetChild(1).GetComponent<Image>();
                imageComponent.sprite = itemSlotButton.GetComponent<InventoryController>().defaultSprite;
            }
        }

    }

    public GameObject LoadItemPrefabByName(string itemName)
    {
        GameObject itemPrefab = Resources.Load<GameObject>("Items/" + itemName);
        if (itemPrefab != null)
        {
            return itemPrefab;
        }
        else
        {
            Debug.LogWarning($"Prefab  {itemName} not found in Resources/Items/");
            return null;
        }
    }

    public void CreateItemData() { 
        List<ItemSlot> itemSlots = new List<ItemSlot>();

        for (int i = 0; i <= 4; i++) {
            ItemSlot obj = new ItemSlot
            {
                id = i,
                name = string.Empty,
                isEmpty = true
            };
            itemSlots.Add(obj);
        }


        SlotsContainer container = new SlotsContainer {
            itemSlots = itemSlots
        };

        string json = JsonUtility.ToJson(container, true);

        File.WriteAllText(savePath, json);
    }

    public void DeleteItemFromInventory(int slotIndex) {
        string json = File.ReadAllText(savePath);
        SlotsContainer container = JsonUtility.FromJson<SlotsContainer>(json);
        ItemSlot slotToUpdate = container.itemSlots.Find(o => o.id == slotIndex);

        if (slotToUpdate != null) {
            slotToUpdate.name = null;
            slotToUpdate.isEmpty = true;
        }
        else {
            Debug.LogWarning($"Object with ID {slotIndex} not found.");
        }
        string updatedJson = JsonUtility.ToJson(container, true); // true dla formatowania
        File.WriteAllText(savePath, updatedJson);
    }


}

