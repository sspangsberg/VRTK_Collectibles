using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
    private static GameManager _instance = new GameManager();
    private GameState gameStatus = GameState.PLAYING;
       
    public enum GameState
    {   
        PLAYING = 0,
        WON = 1,
        LOST = -1
    }


    public GameState GameStatus
    {
        get { return gameStatus; }
        set { gameStatus = value; }
    }

    

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.Log("created Singleton....");
                _instance = new GameManager();                
            }

            return _instance;
        }
    }

    private GameManager() {}



    void Awake()
    {
        _instance = this;
    }
}
