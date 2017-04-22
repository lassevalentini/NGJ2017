using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class LastTerrainTimeToLiveUpdater : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameState.Instance.LastTouchedTerrain != null && GameState.Instance.LastTouchedTerrain.LiveTo != null)
        {
            var secondsLeft = (float)(GameState.Instance.LastTouchedTerrain.LiveTo.Value - DateTime.Now).TotalMilliseconds / 1000f;
            GetComponent<Image>().fillAmount = secondsLeft / GameState.Instance.LastTouchedTerrain.GetSecondsToLive();
        }
    }
}
