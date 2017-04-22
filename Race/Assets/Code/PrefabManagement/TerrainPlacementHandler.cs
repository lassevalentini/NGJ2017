using System;
using System.Collections.Generic;
using UnityEngine;

public class TerrainPlacementHandler : MonoBehaviour {

    private Vector3 lastPlacement;

	// Use this for initialization
	void Start () {
        lastPlacement = new Vector3(0, 0, 0);

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PlaceTerrain(RoadSection terrain)
    {
        TerrainBase nextSection;
        switch (terrain)
        {
            case RoadSection.Straight1:
                nextSection = PrefabFactory.Instance.TerrainManager.GetPrefabFromType<Straight1>();
                break;
            default:
                nextSection = PrefabFactory.Instance.TerrainManager.GetPrefabFromType<Straight1>();
                break;
        }

        nextSection.transform.position = lastPlacement + new Vector3(80, 0, 0);
        lastPlacement = nextSection.transform.position;
    }

    
}
