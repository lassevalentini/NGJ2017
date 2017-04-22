using System;
using System.Collections.Generic;
using UnityEngine;

public class TerrainPlacementHandler : MonoBehaviour {

    private static object locationLock = new object();

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

    public void PlaceTerrain(RoadSection terrain)
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
        lock(locationLock)
        {
            lastPlacement += new Vector3(80, 0, 0);
            nextSection.transform.position = lastPlacement;

            if (UnityEngine.Random.Range(0, 1) < 0.5)
            {
                var middle = nextSection.transform.position + new Vector3(40,0,40);
                nextSection.transform.RotateAround(middle, Vector3.up, 180);
            }
        }
    }

    
}
