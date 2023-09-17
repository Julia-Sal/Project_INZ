using UnityEngine;

public class TouchController : MonoBehaviour
{
    private GameObject selectedObject;
    private Vector3 touchStartPos;
    private Vector3 objectStartPos;
    private bool isMoving = false;
    private Rigidbody rb;
    public float moveSpeed = 0.1f; // Adjust this value for slower or faster movement

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0); // Get the first touch (assuming one finger touch)

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    HandleTouchBegin(touch);
                    rb = selectedObject.GetComponent<Rigidbody>();
                    break;

                case TouchPhase.Moved:
                    HandleTouchMove(touch);
                    break;

                case TouchPhase.Ended:
                    HandleTouchEnd(touch);
                    break;
            }
        }
    }

    private void HandleTouchBegin(Touch touch)
    {
        Ray ray = Camera.main.ScreenPointToRay(touch.position);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            selectedObject = hit.collider.gameObject;
            touchStartPos = new Vector3(touch.position.x, 0, touch.position.y);
            objectStartPos = selectedObject.transform.position;
            if (selectedObject.CompareTag("Item"))
            {
                isMoving = true;
            }
        }
    }

    private void HandleTouchMove(Touch touch)
    {
        if (isMoving && selectedObject != null)
        {
            rb.constraints |= RigidbodyConstraints.FreezePositionY;
            selectedObject.GetComponent<Collider>().enabled = false;

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

    private void HandleTouchEnd(Touch touch)
    {
        if (isMoving && selectedObject != null)
        {
           
            /*
            // Przyk³ad:
            if (selectedObject.CompareTag("Button"))
            {
                // Tutaj podejmij dzia³ania zwi¹zane z wciœniêciem przycisku
                // selectedObject to przycisk, mo¿esz u¿yæ jego tagu lub innego sposobu identyfikacji
            }*/

            selectedObject.GetComponent<Collider>().enabled = true;
            rb.constraints &= ~RigidbodyConstraints.FreezePositionY;
            selectedObject = null;
            isMoving = false;
        }
    }
}
