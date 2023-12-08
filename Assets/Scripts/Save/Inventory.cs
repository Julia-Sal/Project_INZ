using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    
}

[System.Serializable]
public class ItemSlot {
    public int id;
    public string name;
    public bool isEmpty;
}

[System.Serializable]
public class SlotsContainer {
    public List<ItemSlot> itemSlots;
}
