using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TouchController : MonoBehaviour
{
    private GameObject selectedObject;
    private Vector3 touchStartPos;
    private Vector3 objectStartPos;
    private bool isMoving = false;
    private Rigidbody rb;
    public Item lastDragged;
    public LayerMask itemLayer;
    public LayerMask interactiveLayer;
    public LayerMask joystickLayer;
    private RaycastHit hit;
    public Camera camera;
    private GameObject interactiveObject;

    private void Update(){
        if (Input.touchCount > 0){
            Touch touch = Input.GetTouch(0); // Get the first touch (assuming one finger touch)
            Ray ray = camera.ScreenPointToRay(touch.position);
            
            switch (touch.phase)
            {
                case TouchPhase.Began:

                    if (!IsPointerOverUIObject(touch.position)) {
                        if (Physics.Raycast(ray, out hit, Mathf.Infinity, itemLayer))
                        {   //przypadek gdy dotkni�to przedmiot
                            ItemGotGrabbed(touch, hit);
                            }
                        else if (Physics.Raycast(ray, out hit, Mathf.Infinity, interactiveLayer))
                        {
                            //przypadek gdy wywo�ano interakcj�
                            InteractionInterface interactiveObject = hit.collider.GetComponent<InteractionInterface>();
                            if (interactiveObject != null)
                            {
                                interactiveObject.interact();
                            }
                        }
                    }
                    break;

                case TouchPhase.Moved:
                    if (lastDragged.id != 0 && hit.collider != null) {
                        //Poruszaj obiektem
                        moveObject(touch, hit);
                        break;


                    }
                    else if (selectedObject != null) {
                        //Przedmiot zosta� dodany do ekwipunku
                            itemGotAddedToInventory();
                            selectedObject.GetComponent<Pickup>().resetPickup();
                        break;
                    }
                    else if (Physics.Raycast(ray, out hit, Mathf.Infinity, itemLayer))
                    {
                        //Sprawdzaj czy podczas ruszania palcem nie "z�apano" itemu je�li ju� nie poruszamy obiektem
                        ItemGotGrabbed(touch, hit);
                        break;
                    }
                    
                        break;
                    

                case TouchPhase.Ended:
                    if (isMoving && selectedObject != null)
                    {
                        selectedObject.GetComponent<Pickup>().resetPickup();
                        itemGotMoved(touch);
                    }
                    break;
            }
        }
    }

    private void ItemGotGrabbed(Touch touch, RaycastHit hit)
    {
        selectedObject = hit.collider.gameObject;

        if (selectedObject.CompareTag("Item")) {
                touchStartPos = new Vector3(touch.position.x, 0, touch.position.y);
                objectStartPos = selectedObject.transform.position;
                rb = selectedObject.GetComponent<Rigidbody>();
                selectedObject.GetComponent<Pickup>().pickup();
                selectedObject.GetComponent<Collider>().enabled = false;

                isMoving = true;
        }
        else {
                selectedObject = null;
        }
    }

    private void moveObject(Touch touch, RaycastHit hit)
    {
        if (isMoving && selectedObject != null)
        {
            Vector3 touchPos = new Vector3(touch.position.x, touch.position.y, 0);
            Ray ray = camera.ScreenPointToRay(touchPos);
            if (Physics.Raycast(ray, out hit))
            {
                Vector3 targetPosition = hit.point;
                targetPosition.y = objectStartPos.y;
                selectedObject.transform.position = targetPosition;
            }
        }
    }

    private void itemGotMoved(Touch touch){
        selectedObject.GetComponent<Collider>().enabled = true;
            
        selectedObject = null;
        isMoving = false;   
    }

    private void itemGotAddedToInventory(){
        Destroy(selectedObject);
    }


    bool IsPointerOverUIObject(Vector2 touchPosition) //Do poprawy
    {
        // Tworzenie eventData potrzebnego do raycastingu UI
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = touchPosition;

        // Lista hit�w, w kt�rej zapisywane b�d� trafienia raycastingu
        var results = new List<RaycastResult>();

        // Przeprowadzenie raycastingu na elemencie UI
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);

        // Sprawdzenie, czy s� trafienia
        return results.Count > 0;
    }
}
