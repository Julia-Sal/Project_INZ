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

    //teraz funkcja kiedy ma by� dodawany item do eq
    //ta jest na chwil�


    //je�li na odpowiednim miejscu wywo�aj pickup
}
