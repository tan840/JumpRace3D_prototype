using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncePlatform : MonoBehaviour
{
    private Animator anim;
    private ParticleSystem _bounce;
    public GameObject particle_Bounce;
    




    private void Awake()
    {
        anim = GetComponent<Animator>();
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            anim.SetTrigger("bounce");
            GameObject p = PoolingManager.instance.UseObject(particle_Bounce, transform.position, transform.rotation);
            _bounce = p.transform.GetChild(0).GetComponent<ParticleSystem>();
            ParticleReturn(p);
        }

    }
    void ParticleReturn(GameObject p)
    {
        PoolingManager.instance.ReturnObject(p, 2f);
    }
    

}
