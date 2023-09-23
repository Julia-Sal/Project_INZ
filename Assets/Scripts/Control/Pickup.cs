using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public Item item;
    public Item lastDragged;

    public void pickup() {
        lastDragged.id = item.id;
        lastDragged.item = item.item;
    }

    public void resetPickup() {
        lastDragged.id = 0;
        lastDragged.item = null;
    }
}
