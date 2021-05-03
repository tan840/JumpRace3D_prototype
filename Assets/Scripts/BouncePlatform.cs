using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BouncePlatform : MonoBehaviour
{
    private int count = 0;
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
            count++;
            anim.SetTrigger("bounce");
            GameObject p = poolingManager.UseObject(particle_Bounce, transform.position, transform.rotation);
            //_bounce = p.transform.GetChild(0).GetComponent<ParticleSystem>();
            ParticleReturn(p);
            if (count ==1)
            {
                collision.gameObject.transform.DORotate(new Vector3(0, transform.localRotation.y, 0), 0.5f);
            }
            gameManager.LevelCompleteBar();
        }

    }
    void ParticleReturn(GameObject p)
    {
        poolingManager.ReturnObject(p, 2f);
    }
    

}
