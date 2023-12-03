using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class InventoryController : MonoBehaviour
{   
    public GameObject itemInInventory;
    public Image image;
    public Item lastDragged;
    public Sprite defaultSprite;
    private GameObject objectFromInventory;
    public Transform parent;

    public void OnPointerExit() {
        if (!checkIfSlotIsEmpty()) {
            objectFromInventory = itemInInventory;
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
                    itemInInventory = null;
                }
            }
        }
    }

    public void setImage(Item lastDragged){
        if (image != null && lastDragged != null && itemInInventory != null) {
            SpriteRenderer itemSpriteRenderer = itemInInventory.GetComponentInChildren<SpriteRenderer>();
            image.sprite = itemSpriteRenderer.sprite;
        }
    }

    public void OnPointerEnter(){
        
        if (lastDragged.id != 0 && checkIfSlotIsEmpty()) {
            Debug.Log(lastDragged.item);
            itemInInventory = lastDragged.item;
            setImage(lastDragged);
            lastDragged.id = 0;
        }

        SaveInventory saveInventory = new SaveInventory();
        saveInventory.SaveItemData(itemInInventory);
    }

    public bool checkIfSlotIsEmpty() {
        return image.sprite.Equals(defaultSprite);
    }

}
