using UnityEngine;

public class Pickup : MonoBehaviour
{
    public Item lastDragged;
    public Item item;

    public void pickup() {
        lastDragged.id = item.id;
        lastDragged.item = item.item;
    }

    public void resetPickup() {
        lastDragged.id = 0;
        lastDragged.item = null;
    }
}
