using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// This handles the Level transitions
/// </summary>
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
        currrentLevel = 0;
        //print(currrentLevel);
    }
    public void SetCurrentLevel()
    {
        if (currrentLevel>=leveldata.Length)
        {
            currrentLevel = leveldata.Length;
            //print("greater");
        }
        else if(currrentLevel < leveldata.Length)
        {
            //print("less");
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
        
        //gameManager.startPos = leveldata[currrentLevel].startingPos;
        if (currrentLevel>2)
        {
            leveldata[2].Level.SetActive(true);
            leveldata[1].Level.SetActive(false);
            gameManager.startPos = leveldata[2].startingPos;
        }
        else
        {
            leveldata[currrentLevel].Level.SetActive(true);
            leveldata[currrentLevel - 1].Level.SetActive(false);
            gameManager.startPos = leveldata[currrentLevel].startingPos;
        }
        
        //print(currrentLevel);
        
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
