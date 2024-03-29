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
    public int slotIndex;
    public bool isDragged = false;

    public void OnPointerExit() {
        if (!CheckIfSlotIsEmpty()) {
            objectFromInventory = itemInInventory;
            TakeItemFromInventory();
        }       
    }

    private void TakeItemFromInventory() {
        if (Input.touchCount > 0) {
            Touch touch = Input.GetTouch(0);
           
            if (touch.phase == TouchPhase.Moved && !isDragged) {
                Vector3 touchPos = new Vector3(touch.position.x, touch.position.y, 0);
                Ray ray = Camera.main.ScreenPointToRay(touchPos);
                
                if (Physics.Raycast(ray, out RaycastHit hit)) {
                    //ustalenie pozycji w kt�rej ma si� pojawi� obiekt
                    Vector3 targetPosition = hit.point;
                    targetPosition.y = 0.1f;

                    //tworzenie obiektu
                    CreateObject createObject= new CreateObject();
                    createObject.generateObject(targetPosition, objectFromInventory.name);
                    image.sprite = defaultSprite;
                    itemInInventory = null;

                    SaveInventory saveInventory = new SaveInventory();
                    saveInventory.DeleteItemFromInventory(slotIndex);
                }
            } 
            
        }
        
    }

    void Update() {
        if (Input.touchCount > 0) {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Ended) { 
                isDragged = false;
            }
        }
    }

    public void SetImage(Item lastDragged){
        if (image != null && lastDragged != null && itemInInventory != null) {
            SpriteRenderer itemSpriteRenderer = itemInInventory.GetComponentInChildren<SpriteRenderer>();
            image.sprite = itemSpriteRenderer.sprite;
        }
    }

    public void OnPointerEnter(){
        if (lastDragged.id != 0 && CheckIfSlotIsEmpty()) {
            itemInInventory = lastDragged.item;
            SetImage(lastDragged);
            lastDragged.id = 0;
            isDragged = true;

            SaveInventory saveInventory = new SaveInventory();
            saveInventory.SaveItemData(itemInInventory.name, slotIndex); 
        }

        
    }

    public bool CheckIfSlotIsEmpty() {
        return image.sprite.Equals(defaultSprite);
    }

    public Transform details;
    public void ShowDetails() {
        if (itemInInventory != null && itemInInventory.GetComponent<Pickup>().item.isInteractable) {
            details.gameObject.SetActive(true);
            details.GetComponent<Image>().sprite = itemInInventory.GetComponent<SpriteRenderer>().sprite;
        }
    }

}
