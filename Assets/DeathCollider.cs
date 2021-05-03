using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCollider : MonoBehaviour
{
    public GameObject splash;

    PoolingManager poolingManager;
    GameManager gameManager;
    MenuManager menuManger;
    private void Start()
    {
        poolingManager = PoolingManager.instance;
        gameManager = GameManager.instance;
        menuManger = MenuManager.instance;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameObject p = PoolingManager.instance.UseObject(splash, other.transform.position, other.transform.rotation);
            poolingManager.ReturnObject(p, 1f) ;
            gameManager.state = GameManager.GameState.Dead;
            menuManger.ShowLevelFailedPannel();
            gameManager.PlayerDied();
            
        }
    }
   
}
