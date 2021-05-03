using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FinishLine : MonoBehaviour
{
    [SerializeField] Animator anim;
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        LevelManager.instance.SetCurrentLevel();
        GameManager.instance.state = GameManager.GameState.finish;
        GameManager.instance.slider.DOValue(1f,0.5f);
        anim = collision.gameObject.transform.GetChild(0).GetComponent<Animator>();
        anim.Play("BellyDance");
        LevelManager.instance.currrentLevel++;
        MenuManager.instance.ShowLevelCompletePannel();
    }

 
}
