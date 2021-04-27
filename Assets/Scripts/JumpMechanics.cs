using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpMechanics : MonoBehaviour
{
    public float jumpForce = 100;


    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Platform1"))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, 0f);
        }
    }
}
