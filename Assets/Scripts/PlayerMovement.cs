using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveForce = 5;
    public float turnSpeed;


    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
             Touch _currentPrimaryTouch = Input.GetTouch(0);
           // _currentTouchPosition = _currentPrimaryTouch.position;

            //touch started
            if (_currentPrimaryTouch.phase == TouchPhase.Began)
            {

            }
                //TouchStart();

            //touch going on
            else if (_currentPrimaryTouch.phase == TouchPhase.Moved)
                {

                }
                //TouchOnGoing();

            //touch ended
            else if (_currentPrimaryTouch.phase == TouchPhase.Ended)
            //TouchEnded();
            {

            }

            //Note: the other two phases are Stationary & Cancelled
        }
        if (Input.GetKey(KeyCode.W))
        {
            MobileInput();
            //print("W true");
        }
        else
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, 0f);
            //print("W false");
        }
    }

    private void MobileInput()
    {
        rb.AddRelativeForce(Vector3.forward * moveForce * Time.deltaTime, ForceMode.Force);
        //print("W true");
        //rb.velocity = Vector3.zero;
    }
}
