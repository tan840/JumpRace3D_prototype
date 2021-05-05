using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Cinemachine;
using DG.Tweening;
//using UnityEngine.UI;

/// <summary>
/// Handles the Game progression
/// </summary>
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
    [SerializeField] ParticleSystem[] playerParticle;

    MenuManager menumanager;
    LevelManager levelManager;
    Rigidbody rb;
    Animator anim;
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
        levelManager = LevelManager.instance;
        menumanager = MenuManager.instance;
        startPos = levelManager.leveldata[levelManager.CurrentLevel].startingPos;
        finishPos = levelManager.leveldata[levelManager.CurrentLevel].finishPos;

        maxDistance = getDistance();
        state = GameState.Menu;
        rb = player.transform.GetComponent<Rigidbody>();
        anim = player.transform.GetChild(0).GetComponent<Animator>();
    }

    public void ResetLevel()
    {
        rb.velocity = Vector3.zero;
        slider.value = 0f;
        menumanager.startPannel.SetActive(true);
        player.position = startPos.position;
        player.DORotate(new Vector3(0f,startPos.localRotation.eulerAngles.y,0f), 0.5f);       
        player.transform.GetChild(0).transform.DOLocalRotate(new Vector3(0, 0, 0), 1f);
        
        rb.useGravity = false;
        anim.Play("Idle");
        
        if (vCam.LookAt == null && vCam.Follow == null)
        {
            vCam.LookAt = player;
            vCam.Follow = player;
        }
        
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
        foreach (ParticleSystem item in playerParticle)
        {
            item.Play();

        }
        Invoke("ParticleDeactive", 0.75f);
        
    }
    void ParticleDeactive()
    {
        foreach (ParticleSystem item in playerParticle)
        {
            item.Stop();
        }
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
