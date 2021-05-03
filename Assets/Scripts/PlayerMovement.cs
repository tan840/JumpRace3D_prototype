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
    GameManager gameManager;
    MenuManager menuManager;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
    }
    private void Start()
    {
        gameManager = GameManager.instance;
        menuManager = MenuManager.instance;
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            gameManager.state = GameManager.GameState.Started;
            if (gameManager.state == GameManager.GameState.Started && gameManager.state != GameManager.GameState.finish)
            {
                rb.useGravity = true;
                menuManager.HideStartPannel();
                _currentPrimaryTouch = Input.GetTouch(0);
                _currentTouchPosition = _currentPrimaryTouch.position;
                MobileInput();            
                if (_currentPrimaryTouch.phase == TouchPhase.Moved)
                {
                    RotatePlayer();
                }
                else if (_currentPrimaryTouch.phase == TouchPhase.Ended)
                {
                    rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, 0f);
                }
            }
            
        }
#if UNITY_EDITOR
        if (Input.GetKey(KeyCode.W))
        {
            gameManager.state = GameManager.GameState.Started;
            if (gameManager.state == GameManager.GameState.Started && gameManager.state != GameManager.GameState.finish)
            {
                rb.useGravity = true;
                menuManager.HideStartPannel();
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
        float rotY = _currentPrimaryTouch.deltaPosition.x * horizontalSpeed * 3 * Mathf.Deg2Rad;
                //target.Rotate(0, rotY, 0);
                transform.DORotate(new Vector3(0, rotY, 0), 0.15f, RotateMode.LocalAxisAdd);
    }


    private void MobileInput()
    {
        rb.AddRelativeForce(Vector3.forward * moveForce * Time.deltaTime, ForceMode.Force);
 
    }
}
