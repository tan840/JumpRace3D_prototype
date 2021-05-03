using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public LevelData[] leveldata;
    public int currrentLevel =1;

    public static LevelManager instance;
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
        currrentLevel = PlayerPrefs.GetInt("Level");
    }
    public void SetCurrentLevel()
    {
        currrentLevel++;
        PlayerPrefs.SetInt("Level", currrentLevel);
    }
    public void LoadNextLevel()
    {
        if (GameManager.instance.state == GameManager.GameState.finish)
        {
            currrentLevel = PlayerPrefs.GetInt("Level");
            print(currrentLevel);
            leveldata[currrentLevel - 1].Level.SetActive(false);
            leveldata[currrentLevel].Level.SetActive(true);
            print(currrentLevel);
        }
    }
    public void Levelup()
    {
        currrentLevel++;
        if (currrentLevel > leveldata.Length)
        {
            currrentLevel = leveldata.Length + 1;
            PlayerPrefs.SetInt("Level", currrentLevel);
        }
        else
        {
            PlayerPrefs.SetInt("Level", currrentLevel);
        }
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
