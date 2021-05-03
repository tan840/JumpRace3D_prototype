using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject startPannel;
    public GameObject levelFailedPannel;
    public GameObject levelCompletePannel;

    public static MenuManager instance;
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
    }
    public void Btn_LevelComplete()
    {
        LevelManager.instance.LoadNextLevel();
        levelCompletePannel.SetActive(false);
    }
    public void ShowLevelFailedPannel()
    {
        levelFailedPannel.SetActive(true);
    }
    public void Btn_LevelFailed()
    {
        levelFailedPannel.SetActive(false);
    }
    #endregion
}
