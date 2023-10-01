using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{
    public Image image;
    public Item lastDragged;
    public Sprite defaultSprite;
    public InventorySlot inventorySlot;
    private GameObject objectFromInventory;

    public void OnPointerExit() {
        
        if (!checkIfSlotIsEmpty()) {Debug.Log("take item from inventory1");
            objectFromInventory = inventorySlot.item;
            takeItemFromInventory();
        }       
    }

    private void takeItemFromInventory() { 
        if (Input.touchCount > 0) {
            Touch touch = Input.GetTouch(0);
            Debug.Log("take item from inventory");
            if (touch.phase == TouchPhase.Moved) {
                Vector3 touchPos = new Vector3(touch.position.x, touch.position.y, 0);
                Ray ray = Camera.main.ScreenPointToRay(touchPos);

                if (Physics.Raycast(ray, out RaycastHit hit)) {
                    Vector3 targetPosition = hit.point;
                    targetPosition.y = 0.5f;
                    Instantiate(objectFromInventory, targetPosition, objectFromInventory.transform.rotation);
                    image.sprite = defaultSprite;
                }
            }
        }
    }

    public void setImage(Item lastDragged){
        if (image != null && lastDragged != null && inventorySlot.item != null) {
            SpriteRenderer itemSpriteRenderer = inventorySlot.item.GetComponentInChildren<SpriteRenderer>();
            image.sprite = itemSpriteRenderer.sprite;
        }
    }

    public void OnPointerEnter(){
        
        if (lastDragged.id != 0 && checkIfSlotIsEmpty()) {Debug.Log("add item to inventory");
            setImage(lastDragged);
            inventorySlot.item = lastDragged.item;
            lastDragged.id = 0;
        } 
    }

    public bool checkIfSlotIsEmpty() {
        Debug.Log("check if slot is empty");
        return image.sprite.Equals(defaultSprite);

    }

}
