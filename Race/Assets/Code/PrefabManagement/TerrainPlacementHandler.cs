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
            default:
                nextSection = PrefabFactory.Instance.TerrainManager.GetPrefabFromType<StraightRoad>();
                break;
        }
        lock(locationLock)
        {
            Debug.LogFormat("Placing new road. Last: {0}", lastPlacement);
            lastPlacement += new Vector3(80, 0, 0);
            Debug.LogFormat("Placing new road. New: {0}", lastPlacement);
            nextSection.transform.position = lastPlacement;
        }
    }

    
}
