using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item Item;

    void Pickup()
    {
        InventoryManager.Instance.Add(Item);
        Destroy(gameObject);
    }

    //teraz funkcja kiedy ma byæ dodawany item do eq
    //ta jest na chwilê


    //jeœli na odpowiednim miejscu wywo³aj pickup
}
