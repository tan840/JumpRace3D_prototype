using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterCollider : MonoBehaviour
{
    int counter = 0;
    private void OnTriggerEnter(Collider other)
    {
        counter++;
        if(counter ==1)
        {
            GameManager.instance.TextDisplay("Perfect");
        }
        
    }
}
