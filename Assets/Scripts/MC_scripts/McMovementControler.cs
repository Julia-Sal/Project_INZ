using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class McMovementControler : MonoBehaviour
{
    public Joystick joystick;
    private Rigidbody rb;
    public float movespeed;
    public LayerMask LayerIsGround;
    public GameObject touchController;
       

    // Start is called before the first frame update
    void Start() {
        joystick = FindObjectOfType<Joystick>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {
        Vector3 movement = new Vector3(joystick.Horizontal * movespeed, rb.velocity.y, joystick.Vertical * movespeed);
        rb.velocity = movement;
        bool isMoving = movement.magnitude > 0.1f;

        if (isMoving) {
            touchController.SetActive(false);
        }
        else {
            touchController.SetActive(true);
        }
    }
}
