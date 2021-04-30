using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{
    public float moveForce = 5;
    public float turnSpeed;
    public float horizontalSpeed = 5;


    private Rigidbody rb;
    private Touch _currentPrimaryTouch;
    Vector2 _currentTouchPosition;
    float _firstTouchTime;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            GameManager.instance.state = GameManager.GameState.Started;
            if (GameManager.instance.state == GameManager.GameState.Started)
            {
                GameManager.instance.HideTaptoPlayText();
                _currentPrimaryTouch = Input.GetTouch(0);
                _currentTouchPosition = _currentPrimaryTouch.position;
                MobileInput();
                //touch started
                if (_currentPrimaryTouch.phase == TouchPhase.Began)
                {
                    TouchStart();
                }
                else if (_currentPrimaryTouch.phase == TouchPhase.Moved)
                {
                    RotatePlayer();
                }
                //TouchOnGoing();

                //touch ended
                else if (_currentPrimaryTouch.phase == TouchPhase.Ended)
                //TouchEnded();
                {

                }
            }
            
        }
#if UNITY_EDITOR
        if (Input.GetKey(KeyCode.W))
        {
            GameManager.instance.state = GameManager.GameState.Started;
            if (GameManager.instance.state == GameManager.GameState.Started)
            {
                GameManager.instance.HideTaptoPlayText();
                MobileInput();
            }        
        }
        else
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, 0f);          
        }

#endif
    }

    void RotatePlayer()
    {
        float rotY = _currentPrimaryTouch.deltaPosition.x * -horizontalSpeed * 3 * Mathf.Deg2Rad;
                //target.Rotate(0, rotY, 0);
                transform.DORotate(new Vector3(0, rotY, 0), 0.15f, RotateMode.LocalAxisAdd);
    }

    void TouchStart()
    {
        _firstTouchTime = Time.time;
    }

    private void MobileInput()
    {
        rb.AddRelativeForce(Vector3.forward * moveForce * Time.deltaTime, ForceMode.Force);
 
    }
}
