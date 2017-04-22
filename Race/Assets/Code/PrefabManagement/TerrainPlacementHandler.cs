using System;
using System.Collections.Generic;
using UnityEngine;

public class TerrainPlacementHandler : MonoBehaviour {

    private Vector3 _lastPlacement;
    private Vector3 lastPlacement {
        get
        {
            if (_lastPlacement == null)
            {
                _lastPlacement = new Vector3(0, 0, 0);
            }
            return _lastPlacement;
        }
        set
        {
            _lastPlacement = value;
        }
    }

    // Use this for initialization
    void Start () {
        

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public TerrainBase GetTerrainFromRoadSection(RoadSection terrain)
    {
        TerrainBase nextSection;
        switch (terrain)
        {
            case RoadSection.Straight:
                nextSection = PrefabFactory.Instance.TerrainManager.GetPrefabFromType<StraightRoad>();
                break;
            case RoadSection.Bendy:
                nextSection = PrefabFactory.Instance.TerrainManager.GetPrefabFromType<BendyRoad>();
                break;
            case RoadSection.Bumpy:
                nextSection = PrefabFactory.Instance.TerrainManager.GetPrefabFromType<BumpyRoad>();
                break;
            case RoadSection.Curvy:
                nextSection = PrefabFactory.Instance.TerrainManager.GetPrefabFromType<CurvyRoad>();
                break;
            case RoadSection.Splitting:
                nextSection = PrefabFactory.Instance.TerrainManager.GetPrefabFromType<SplittingRoad>();
                break;
            case RoadSection.Windy:
                nextSection = PrefabFactory.Instance.TerrainManager.GetPrefabFromType<WindyRoad>();
                break;
            default:
                nextSection = PrefabFactory.Instance.TerrainManager.GetPrefabFromType<StraightRoad>();
                break;
        }
        return nextSection;
    }
    public void PlaceTerrain(RoadSection terrain)
    {
        var nextSection = GetTerrainFromRoadSection(terrain);

        if (GameState.Instance.Gold >= nextSection.GetCost())
        {
            Debug.LogFormat("Could buy {0}. Gold: {1}, Cost: {2}", terrain, GameState.Instance.Gold, nextSection.GetCost());
            GameState.Instance.Gold -= nextSection.GetCost();
            lastPlacement += new Vector3(80, 0, 0);
            nextSection.transform.position = lastPlacement;

            //if (UnityEngine.Random.Range(0, 100) < 50)
            //{
            //    Debug.LogFormat("Rotating {0}", terrain);
            //    nextSection.transform.Rotate(Vector3.up, 180);
            //    //nextSection.transform.position += new Vector3(0, 0, -80);
            //}
        }
        else
        {
            //TODO: Error message?
            Debug.LogFormat("Could not buy {0}. Gold: {1}, Cost: {2}", terrain, GameState.Instance.Gold, nextSection.GetCost());
            PrefabFactory.Instance.TerrainManager.RecyclePrefab(nextSection.gameObject);
        }
    }

    
}
