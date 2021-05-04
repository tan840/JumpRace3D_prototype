using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public LevelData[] leveldata;
    [SerializeField]private int currrentLevel = 0;

    public static LevelManager instance;

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
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        //print(currrentLevel);
        gameManager = GameManager.instance;
        //Debug.Log(gameManager);
        currrentLevel = PlayerPrefs.GetInt("Level");
        //print(currrentLevel);
    }
    public void SetCurrentLevel()
    {
        if (currrentLevel> leveldata.Length)
        {
            currrentLevel = leveldata.Length;
        }
        else
        {
            currrentLevel++;
        }

        PlayerPrefs.SetInt("Level", currrentLevel);
    }
    public int CurrentLevel
    {
        get { return currrentLevel; }
      
    }
    public void LoadNextLevel()
    {
              
        leveldata[currrentLevel - 1].Level.SetActive(false);
        leveldata[currrentLevel].Level.SetActive(true);
        //print(currrentLevel);
        gameManager.startPos = leveldata[currrentLevel].startingPos;
        gameManager.ResetLevel();
        
    }
    public void Levelup()
    {
        SetCurrentLevel();
    }

}

[System.Serializable]
public class LevelData
{
    public string LevelName;
    public Transform startingPos;
    public Transform finishPos;
    public GameObject Level;
}
