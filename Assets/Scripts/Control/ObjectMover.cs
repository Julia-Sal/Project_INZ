using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    private Vector3 touchStartPos;
    private Vector3 objectStartPos;
    private Quaternion objectStartRotation;
    private bool isMoving = false;
    
    public float moveSpeed = 0.1f; // Adjust this value for slower or faster movement

    private void Start()
    {
        objectStartRotation = transform.rotation;
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0); // Get the first touch (assuming one finger touch)
            Rigidbody rb = gameObject.GetComponent<Rigidbody>();

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    // Raycast to check if the touch hits this object
                    Ray ray = Camera.main.ScreenPointToRay(touch.position);
                    RaycastHit hit;

                    if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject)
                    {
                        // Record the initial touch position, object position, and rotation.
                        touchStartPos = new Vector3(touch.position.x, 0, touch.position.y);
                        objectStartPos = transform.position;
                        isMoving = true;
                    }
                    break;

                case TouchPhase.Moved:
                    if (isMoving)
                    {
                        gameObject.GetComponent<Collider>().enabled = false;
                       
                        rb.constraints |= RigidbodyConstraints.FreezePositionY;

                        /*
                        // Convert touch.position to Vector3
                        Vector3 touchPos = new Vector3(touch.position.x, 0, touch.position.y);
                        Debug.Log("touch x: "+touchPos.x);
                        // Calculate the movement vector and move the object accordingly.
                        Vector3 delta = touchPos - touchStartPos;
                        Vector3 newPosition = new Vector3(objectStartPos.x + delta.x * moveSpeed, objectStartPos.y, objectStartPos.z + delta.z * moveSpeed);
                        

                        //Debug.Log("new x: " + newPosition.x);
                        transform.position = newPosition;*/

                        Vector3 touchPos = new Vector3(touch.position.x, touch.position.y, 0);
                        Debug.Log("touch x: " + touchPos.x);

                        // Cast a ray from the screen position into the world space.
                        Ray ray1 = Camera.main.ScreenPointToRay(touchPos);
                        if (Physics.Raycast(ray1, out RaycastHit hit1))
                        {
                            // Get the hit point on the object's plane.
                            Vector3 targetPosition = hit1.point;

                            // Ensure the object stays at the same y-coordinate as its starting position.
                            targetPosition.y = objectStartPos.y;

                            // Update the object's position.
                            transform.position = targetPosition;
                        }

                    }
                    break;

                case TouchPhase.Ended:

                    gameObject.GetComponent<Collider>().enabled = true;
                    rb.constraints &= ~RigidbodyConstraints.FreezePositionY;
                    isMoving = false;
                    break;
            }
        }
    }
}
