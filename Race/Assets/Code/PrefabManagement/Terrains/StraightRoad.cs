using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightRoad : TerrainBase
{

    protected override void Init()
    {
        defaultSecondsToLive = 15;
        defaultCost = 15;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

    }
}
