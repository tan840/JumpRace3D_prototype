using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/// <summary>
/// This controls the menu transitions
/// </summary>
public class MenuManager : MonoBehaviour
{
    public GameObject startPannel;
    public GameObject levelFailedPannel;
    public GameObject levelCompletePannel;

    public static MenuManager instance;

    LevelManager levelManager;
    GameManager gameManager;
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
        ShowStartPannel();
    }

    private void Start()
    {
        levelManager = LevelManager.instance;
        gameManager = GameManager.instance;
    }
    #region pannel Show and Hide Functions
    public void ShowStartPannel()
    {
        startPannel.SetActive(true);
    }
    public void HideStartPannel()
    {
        startPannel.SetActive(false);
    }
    public void ShowLevelCompletePannel()
    {
        levelCompletePannel.SetActive(true);
        levelManager.Levelup();
    }
    public void Btn_LevelComplete()
    {
        levelCompletePannel.SetActive(false);
        levelManager.LoadNextLevel();
        
    }
    public void ShowLevelFailedPannel()
    {
        levelFailedPannel.SetActive(true);
    }
    public void Btn_LevelFailed()
    {
        levelFailedPannel.SetActive(false);
        gameManager.ResetLevel();
        
    }
    #endregion
}
