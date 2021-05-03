using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Cinemachine;
using DG.Tweening;
//using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private Vector3 playerInitialPos;
    public Transform player;
    public TextMeshProUGUI text_perfect;
    public GameObject pannel_tapToPlay;
    public CinemachineVirtualCamera vCam;
    // level progress
    public Transform startPos;
    public Transform finishPos;
    public Slider slider;
    public float maxDistance;
    float distance;

    public enum GameState { Menu, Started, Dead, finish }
    public GameState state;

    public static GameManager instance;
 
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
      
        
    }
    void Start()
    {
        startPos = LevelManager.instance.leveldata[LevelManager.instance.currrentLevel - 1].startingPos;
        finishPos = LevelManager.instance.leveldata[LevelManager.instance.currrentLevel - 1].finishPos;

        maxDistance = getDistance();
        state = GameState.Menu;
        
    }
   
    public void PlayerDied()
    {
        if (state == GameState.Dead)
        {
            vCam.LookAt = null;
            vCam.Follow = null;
        }
    }

    public void TextDisplay(string t)
    {

        text_perfect.text = t;
        Invoke("HideText", 1.5f);
    }
    void HideText()
    {
        text_perfect.text = "";
    }
    public void HideTaptoPlayText()
    {
        pannel_tapToPlay.SetActive(false);
    }

    public void LevelCompleteBar()
    {
        distance = Vector3.Distance(player.position, finishPos.position);
        if (player.position.z < finishPos.position.z)
        {        
            slider.DOValue(1-(distance / maxDistance),0.5f);
        }
    }
    float getDistance()
    {
        return Vector3.Distance(startPos.position, finishPos.position);
    }
}
