using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterCollider : MonoBehaviour
{
    int counter = 0;
    GameManager gameManager;
    private void Start()
    {
        gameManager = GameManager.instance;
    }
    private void OnTriggerEnter(Collider other)
    {
        counter++;
        if(counter ==1)
        {
            gameManager.TextDisplay("Perfect");
        }
        
    }
}
