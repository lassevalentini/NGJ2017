using UnityEngine;
using System.Collections;

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

    private int _gold = 0;
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

    public static void EndGame()
    {
        Debug.Log("Game end!");
        //UiManager.Instance
    }
}
