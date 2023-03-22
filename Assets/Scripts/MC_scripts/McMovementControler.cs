using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class McMovementControler : MonoBehaviour
{
    public Joystick joystick;
    private Rigidbody rb;
    public float movespeed;
    public LayerMask LayerIsGround;
       

    // Start is called before the first frame update
    void Start()
    {
        joystick = FindObjectOfType<Joystick>();

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector3(joystick.Horizontal * movespeed, rb.velocity.y, joystick.Vertical * movespeed);

    }
}
