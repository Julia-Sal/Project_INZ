using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{
    public Image image;
    public Item lastDragged;
    public Sprite defaultSprite;
    public InventorySlot inventorySlot;
    private GameObject objectFromInventory;
    public Transform parent;

    public void OnPointerExit() {
        
        if (!checkIfSlotIsEmpty()) {
            objectFromInventory = inventorySlot.item;
            takeItemFromInventory();
        }       
    }

    private void takeItemFromInventory() { 
        if (Input.touchCount > 0) {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved) {
                Vector3 touchPos = new Vector3(touch.position.x, touch.position.y, 0);
                Ray ray = Camera.main.ScreenPointToRay(touchPos);

                if (Physics.Raycast(ray, out RaycastHit hit)) {
                    //ustalenie pozycji w której ma siê pojawiæ obiekt
                    Vector3 targetPosition = hit.point;
                    targetPosition.y = 0.5f;

                    //tworzenie obiektu
                    CreateObject createObject= new CreateObject();
                    createObject.generateObject(objectFromInventory, parent, targetPosition);
                    image.sprite = defaultSprite;
                }
            }
        }
    }

    public void setImage(Item lastDragged){
        if (image != null && lastDragged != null && inventorySlot.item != null) {
            SpriteRenderer itemSpriteRenderer = inventorySlot.item.GetComponentInChildren<SpriteRenderer>();
            Debug.Log(itemSpriteRenderer.sprite);
            image.sprite = itemSpriteRenderer.sprite;
        }
    }

    public void OnPointerEnter(){
        
        if (lastDragged.id != 0 && checkIfSlotIsEmpty()) {
            inventorySlot.item = lastDragged.item;
            setImage(lastDragged);
            lastDragged.id = 0;
        } 
    }

    public bool checkIfSlotIsEmpty() {
        return image.sprite.Equals(defaultSprite);

    }

}
