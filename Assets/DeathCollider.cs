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
            GameManager.instance.state = GameManager.GameState.Dead;
            PoolingManager.instance.UseObject(splash, other.transform.position, other.transform.rotation);
        }
    }
}
