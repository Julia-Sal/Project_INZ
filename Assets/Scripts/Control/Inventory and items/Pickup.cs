using UnityEngine;

public class Pickup : MonoBehaviour
{
    public Item lastDragged;
    public Item item;

    public void SetPickup() {
        lastDragged.id = item.id;
        lastDragged.item = item.item;
    }

    public void ResetPickup() {
        lastDragged.id = 0;
        lastDragged.item = null;
    }
}
