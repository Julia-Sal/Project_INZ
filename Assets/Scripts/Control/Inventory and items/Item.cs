using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item/Create New Item")]
public class Item : ScriptableObject
{
    public int id;
    public GameObject item;
    public string name;
    public bool isInteractable;
    public string description;
}
