using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumpyRoad : TerrainBase
{


    protected override void Init()
    {
        secondsToLive = 15;
    }

    // Update is called once per frame
    protected override void Update ()
    {
        base.Update();

    }
}
