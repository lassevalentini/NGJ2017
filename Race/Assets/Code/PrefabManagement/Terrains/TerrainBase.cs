using UnityEngine;
using System.Collections;
using System;

public abstract class TerrainBase : MonoBehaviour
{
    public int Cost;
    protected int defaultCost;


    public int SecondsToLive;
    protected int defaultSecondsToLive;

    public int GetSecondsToLive()
    {
        return SecondsToLive > 0 ? SecondsToLive : defaultSecondsToLive;
    }
    public DateTime? LiveTo;


    // Use this for initialization
    //void Start()
    //{
    //    Init();
    //    Debug.LogFormat("Start {0}", gameObject.name);
    //    liveTo = DateTime.Now.AddSeconds(secondsToLive);
    //}

    protected virtual void Init()
    {
        defaultSecondsToLive = 10;
        defaultCost = 10;
    }

    public int GetCost()
    {
        return Cost > 0 ? Cost : defaultCost;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (LiveTo < DateTime.Now || GameState.Instance.Player.transform.position.x - transform.position.x > 120)
        {
            LiveTo = null;
            Debug.LogFormat("{0} shouldnt live", gameObject.name);

            var explosion = PrefabFactory.Instance.TerrainManager.GetPrefabFromType<Explosion>();
            explosion.transform.position = transform.position + new Vector3(40, 0, 40);

            PrefabFactory.Instance.TerrainManager.RecyclePrefab(gameObject);
        }
    }

    void OnEnable()
    {
        Debug.LogFormat("Enabling {0}", gameObject.name);
        Init();
    }

    void OnDisable()
    {
        LiveTo = null;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.transform.parent.transform.parent.tag == "Player" && LiveTo == null)
        {
            Debug.Log(string.Format("Trigger with terrain and {0} {1}", col.gameObject.transform.parent.transform.parent.name, col.gameObject.transform.parent.transform.parent.tag));
            GameState.Instance.LastTouchedTerrain = this;
            LiveTo = DateTime.Now.AddSeconds(GetSecondsToLive());
        }
    }
    
}
