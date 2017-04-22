using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabFactory {
    // SINGLETON! 
    private static PrefabFactory _prefabFactory;
    public static PrefabFactory Instance
    {
        get
        {
            if (_prefabFactory == null)
            {
                _prefabFactory = new PrefabFactory();
            }
            return _prefabFactory;
        }
    }

    private ManagerBase _terrainManager;
    public ManagerBase TerrainManager
    {
        get
        {
            if (_terrainManager == null)
            {
                var prefab = Resources.Load("TerrainManager");
                var GO = (GameObject.Instantiate(prefab)) as GameObject;
                _terrainManager = GO.GetComponent<ManagerBase>();
            }
            return _terrainManager;
        }
    }


    private TerrainPlacementHandler _terrainPlacementHandler;
    public TerrainPlacementHandler TerrainPlacementHandler
    {
        get
        {
            if (_terrainPlacementHandler == null)
            {
                var prefab = Resources.Load("TerrainPlacementHandler");
                var GO = (GameObject.Instantiate(prefab)) as GameObject;
                _terrainPlacementHandler = GO.GetComponent<TerrainPlacementHandler>();
            }
            return _terrainPlacementHandler;
        }
    }
}
