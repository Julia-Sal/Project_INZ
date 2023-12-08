using System.Collections;
using System.Collections.Generic;
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
        saveMcPosition = new SaveMcPosition();
        saveMcPosition.LoadPosition(player);

        SaveInventory saveInventory = new SaveInventory();
        saveInventory.LoadItemData(itemSlotParent);
        
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
