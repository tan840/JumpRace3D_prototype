using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI text_perfect;
    public TextMeshProUGUI text_tapToPlay;


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
        state = GameState.Menu;

    }

    // Update is called once per frame
    void Update()
    {
        
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
        text_tapToPlay.text = "";
    }
}
