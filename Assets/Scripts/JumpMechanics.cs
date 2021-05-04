using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class JumpMechanics : MonoBehaviour
{
    public float jumpForce = 100;
    public float highJumpForce = 200;


    private Rigidbody rb;
    [SerializeField]private int count = 0;
    [SerializeField]Quaternion targetRotation;
    [SerializeField]private Animator anim;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        anim = transform.GetChild(0).GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Platform1"))
        {
            count++;         
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, 0f);
            anim.Play("Jump");
            targetRotation = collision.gameObject.GetComponent<Transform>().localRotation;
            print(collision.gameObject.GetComponent<Transform>().localRotation);
            transform.DORotate(new Vector3(targetRotation.x, targetRotation.y, targetRotation.z), 0.5f);
            
        }
        if (collision.gameObject.CompareTag("Platform2"))
        {
            rb.AddForce(Vector3.up * highJumpForce, ForceMode.Impulse);
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, 0f);
            anim.Play("Jump");
        }
    }
}
