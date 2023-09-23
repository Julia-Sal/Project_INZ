using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory Slot", menuName = "Slot/Create New Inventory Slot")]
public class InventorySlot : ScriptableObject
{
    public int itemSlot;
    public GameObject item;
}
