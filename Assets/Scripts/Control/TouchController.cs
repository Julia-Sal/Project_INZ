using System.Collections;
using System.Collections.Generic;
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
    public float moveSpeed = 0.1f; // Adjust this value for slower or faster movement
    public Item lastDragged;
    public LayerMask allowedLayer;

    private void Update(){
        if (Input.touchCount > 0){
            
            Touch touch = Input.GetTouch(0); // Get the first touch (assuming one finger touch)
            
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    checkIfItemGotGrabbed(touch);
                    break;

                case TouchPhase.Moved:
                    if (lastDragged.id != 0) {
                        moveObject(touch);
                        break;

                    } else if (selectedObject==null) {
                        checkIfItemGotGrabbed(touch);
                        break;
                    }
                    else {
                        itemGotAddedToInventory();
                        selectedObject.GetComponent<Pickup>().resetPickup();
                        break;
                    }

                case TouchPhase.Ended:
                    if (isMoving && selectedObject != null)
                    {
                        itemGotMoved(touch);
                    }
                    break;
            }
        }
    }

    private void checkIfItemGotGrabbed(Touch touch){
        Ray ray = Camera.main.ScreenPointToRay(touch.position);

        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, allowedLayer)){
            selectedObject = hit.collider.gameObject;
            if (selectedObject.CompareTag("Item")) {
                touchStartPos = new Vector3(touch.position.x, 0, touch.position.y);
                objectStartPos = selectedObject.transform.position;
                rb = selectedObject.GetComponent<Rigidbody>();
                selectedObject.GetComponent<Pickup>().pickup();
                rb.constraints |= RigidbodyConstraints.FreezePositionY;
                selectedObject.GetComponent<Collider>().enabled = false;

                isMoving = true;
            }
            else {
                selectedObject = null;
            }
        }
    }


    private void moveObject(Touch touch)
    {
        if (isMoving && selectedObject != null)
        {
            Vector3 touchPos = new Vector3(touch.position.x, touch.position.y, 0);
            Ray ray = Camera.main.ScreenPointToRay(touchPos);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Vector3 targetPosition = hit.point;
                targetPosition.y = objectStartPos.y;
                selectedObject.transform.position = targetPosition;
            }
        }
    }

    private void itemGotMoved(Touch touch){
        selectedObject.GetComponent<Collider>().enabled = true;
        rb.constraints &= ~RigidbodyConstraints.FreezePositionY;
            
        selectedObject = null;
        isMoving = false;   
    }

    private void itemGotAddedToInventory(){
        Destroy(selectedObject);
    }
}
