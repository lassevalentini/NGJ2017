using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;

public class GameState
{
    // SINGLETON! 
    private static GameState _instance;
    public static GameState Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameState();
            }
            return _instance;
        }
    }

    public int PointsInLastGame;

    public GameState()
    {
        Reset();
    }
    private void Reset()
    {
        _gold = 500;
    }

    internal object GetGold()
    {
        return Gold;
    }

    private GameObject _player;
    public GameObject Player
    {
        get
        {
            if (_player == null)
            {
                _player = GameObject.FindGameObjectsWithTag("Player")[0];
            }
            return _player;
        }
    }

    private int _gold;
    public int Gold {
        get
        {
            return _gold;
        }
        set
        {
            _gold = value;
        }
    }

    public int GetPoints()
    {
        return (int)Player.transform.position.x;
    }

    public void EndGame()
    {
        Debug.Log("Game end!");
        PointsInLastGame = GetPoints();
        Reset();
        SceneManager.LoadScene("GameOver");
    }
}
