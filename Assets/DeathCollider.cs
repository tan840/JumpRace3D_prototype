using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCollider : MonoBehaviour
{
    public GameObject splash;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameObject p = PoolingManager.instance.UseObject(splash, other.transform.position, other.transform.rotation);
            PoolingManager.instance.ReturnObject(p, 1f) ;
            GameManager.instance.state = GameManager.GameState.Dead;
            MenuManager.instance.ShowLevelFailedPannel();
            GameManager.instance.PlayerDied();
            
        }
    }
   
}
