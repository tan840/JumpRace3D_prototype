using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    [SerializeField] Animator anim;
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        GameManager.instance.state = GameManager.GameState.finish;
        GameManager.instance.slider.value = 1f;
        anim = collision.gameObject.transform.GetChild(0).GetComponent<Animator>();
        anim.Play("BellyDance");
        LevelManager.instance.currrentLevel++;
        MenuManager.instance.ShowLevelCompletePannel();
    }

 
}
