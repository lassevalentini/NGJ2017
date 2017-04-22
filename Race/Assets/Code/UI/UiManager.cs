using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager
{
    // SINGLETON! 
    private static UiManager _instance;
    public static UiManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new UiManager();
            }
            return _instance;
        }
    }
    

    
}
