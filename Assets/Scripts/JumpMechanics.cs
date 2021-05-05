using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

/// <summary>
/// Is used to control the jump mechanics
/// </summary>
public class JumpMechanics : MonoBehaviour
{
    public float jumpForce = 100;
    public float highJumpForce = 200;


    private Rigidbody rb;
    //raycastVariable
    Ray ray;
    [SerializeField]float distance;
    RaycastHit hit;
    [SerializeField]private int count = 0;
    [SerializeField]Quaternion targetRotation;
    [SerializeField]private Animator anim;
    [SerializeField] LineRenderer lineRenderer;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = transform.GetChild(0).GetComponent<Animator>();
        lineRenderer.enabled = false;
    }
    void Update()
    {
        ray = new Ray(transform.position, Vector3.down);
        if (Physics.Raycast(ray, out hit, distance))
        {
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, hit.point);
            if (hit.transform.CompareTag("Platform1") || hit.transform.CompareTag("Platform2"))
            {
                //print("platfform");
                lineRenderer.material.color = Color.green;
                
            }
            else
            {
                lineRenderer.material.color = Color.red;
            }
            
        }
        else
        {
            lineRenderer.enabled = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Platform1"))
        {
            count++;         
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, 0f);
            anim.Play("Jump");
            targetRotation.y = collision.gameObject.GetComponent<Transform>().eulerAngles.y ;
            //print(collision.gameObject.GetComponent<Transform>().localRotation);
            transform.DORotate(new Vector3(0f, targetRotation.y, 0f), 0.5f);
            lineRenderer.enabled = true;
            
        }
        if (collision.gameObject.CompareTag("Platform2"))
        {
            rb.AddForce(Vector3.up * highJumpForce, ForceMode.Impulse);
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, 0f);
            anim.Play("Jump");
        }
    }
}
