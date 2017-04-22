using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TerrainSelectorBehavior : MonoBehaviour {

    public KeyCode KeyCode;

    public RoadSection Terrain;

	// Use this for initialization
	void Start () {
        Button btn = gameObject.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);

        var terrain = PrefabFactory.Instance.TerrainPlacementHandler.GetTerrainFromRoadSection(Terrain);
        var cost = terrain.GetCost();
        PrefabFactory.Instance.TerrainManager.RecyclePrefab(terrain.gameObject);


        Text text = gameObject.GetComponentInChildren<Text>();
        text.text += string.Format("\n${0}", cost);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp(KeyCode))
        {
            TaskOnClick();
        }
    }

    void TaskOnClick()
    {
        PrefabFactory.Instance.TerrainPlacementHandler.PlaceTerrain(Terrain);
    }
}
