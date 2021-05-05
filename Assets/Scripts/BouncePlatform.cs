using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BouncePlatform : MonoBehaviour
{
 
    private Animator anim;
    private ParticleSystem _bounce;
    public GameObject particle_Bounce;
    PoolingManager poolingManager;
    GameManager gameManager;




    private void Awake()
    {
        anim = GetComponent<Animator>();
        
    }

    private void Start()
    {
        poolingManager = PoolingManager.instance;
        gameManager = GameManager.instance;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            anim.SetTrigger("bounce");
            GameObject p = poolingManager.UseObject(particle_Bounce, transform.position, transform.rotation);
            ParticleReturn(p);
            
            gameManager.LevelCompleteBar();
        }

    }
    void ParticleReturn(GameObject p)
    {
        poolingManager.ReturnObject(p, 2f);
    }
    

}
