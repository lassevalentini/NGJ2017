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
    public bool IsGameActive;
    public int PointsInLastGame;

    public GameState()
    {
        SceneManager.sceneLoaded += SceneManager_sceneLoaded;
        Reset();
    }

    private void SceneManager_sceneLoaded(Scene scene, LoadSceneMode loadMode)
    {
        if (scene.name == "Scene")
        {
            Reset();
        }
    }

    private void Reset()
    {
        _gold = 500;
        IsGameActive = true;
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
        if (IsGameActive)
        {
            return (int)Player.transform.position.x;
        }
        else
        {
            return PointsInLastGame;
        }
    }

    public void EndGame()
    {
        Debug.Log("Game end!");
        PointsInLastGame = GetPoints();
        IsGameActive = false;
        SceneManager.LoadScene("GameOver");
    }
}
