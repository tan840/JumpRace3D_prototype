using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FinishLine : MonoBehaviour
{
    GameManager gameManager;
    LevelManager levelManager;
    MenuManager menuManager;
    [SerializeField] Animator anim;
    private void Start()
    {
        gameManager = GameManager.instance;
        levelManager = LevelManager.instance;
        menuManager = MenuManager.instance;
    }
    private void OnCollisionEnter(Collision collision)
    {

        gameManager.state = GameManager.GameState.finish;
        gameManager.slider.DOValue(1f,0.5f);
        anim = collision.gameObject.transform.GetChild(0).GetComponent<Animator>();
        anim.Play("BellyDance");
        levelManager.SetCurrentLevel();
        menuManager.ShowLevelCompletePannel();
    }

 
}
