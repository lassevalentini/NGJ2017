using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindyRoad : TerrainBase
{

    protected override void Init()
    {
        defaultSecondsToLive = 15;
        defaultCost = 8;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

    }
}
