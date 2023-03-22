using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class McAnimBehaviour : MonoBehaviour
{
   
    private Animator animator;

    public GameObject movingLeftObject; 
    public GameObject movingDownObject; // Idle and down
    public GameObject movingRightObject;
    public GameObject movingUpObject;
    public Joystick joystick;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(joystick.Horizontal);

        if (animator != null)
        {
            if (joystick.Horizontal < 0) // if player is moving left
            {
                if (joystick.Vertical > 0 && joystick.Horizontal > -0.35) // if player is moving up
                {
                    animator.SetTrigger("TriggerRunUp");
                    movingDownObject.SetActive(false);
                    movingLeftObject.SetActive(false);
                    movingRightObject.SetActive(false);
                    movingUpObject.SetActive(true);
                }
                else if (joystick.Vertical < 0 && joystick.Horizontal > -0.35) //if player is moving down
                {
                    animator.SetTrigger("TriggerRunDown");
                    movingDownObject.SetActive(true);
                    movingLeftObject.SetActive(false);
                    movingRightObject.SetActive(false);
                    movingUpObject.SetActive(false);
                }
                else
                {
                    animator.SetTrigger("TriggerRunHorizontal"); // set trigger for running animation
                    movingRightObject.SetActive(false); // wy³¹cz model postaci id¹cej w prawo
                    movingDownObject.SetActive(false);
                    movingLeftObject.SetActive(true);
                    movingUpObject.SetActive(false);
                }
            }
            else if (joystick.Horizontal > 0) // if player is moving right
            {
                if (joystick.Vertical > 0 && joystick.Horizontal < 0.35) // if player is moving up
                {
                    animator.SetTrigger("TriggerRunUp");
                    movingDownObject.SetActive(false);
                    movingLeftObject.SetActive(false);
                    movingRightObject.SetActive(false);
                    movingUpObject.SetActive(true);
                }
                else if (joystick.Vertical < 0 && joystick.Horizontal < 0.35) //if player is moving down
                {
                    animator.SetTrigger("TriggerRunDown");
                    movingDownObject.SetActive(true);
                    movingLeftObject.SetActive(false);
                    movingRightObject.SetActive(false);
                    movingUpObject.SetActive(false);
                }
                else
                {
                    animator.SetTrigger("TriggerRunHorizontal"); // set trigger for running animation
                    movingLeftObject.SetActive(false); // wy³¹cz model postaci id¹cej w lewo
                    movingDownObject.SetActive(false);
                    movingRightObject.SetActive(true); // w³¹cz model postaci id¹cej w prawo
                    movingUpObject.SetActive(false);
                }
            }
            else if (joystick.Vertical == 0 && joystick.Horizontal == 0)
            {
                animator.SetTrigger("TriggerIdle");
                movingDownObject.SetActive(true);
                movingLeftObject.SetActive(false);
                movingRightObject.SetActive(false);
                movingUpObject.SetActive(false);

            }
           
        }
    }

}
