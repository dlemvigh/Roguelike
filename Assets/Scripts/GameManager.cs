using UnityEngine;
using System.Collections;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public BoardManager boardScript = null;
    public int playerFoodPoints = 100;
    [HideInInspector]
    public bool playersTurn = true;
    private int level = 3;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        boardScript = GetComponent<BoardManager>();
        InitGame();
    }

    void InitGame()
    {
        boardScript.SetupScene(level);
    }

    public void GameOver()
    {
        enabled = false;
    }
}
