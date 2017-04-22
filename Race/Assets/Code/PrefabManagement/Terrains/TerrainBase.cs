using UnityEngine;
using System.Collections;
using System;

public abstract class TerrainBase : MonoBehaviour
{
    public int Cost;
    protected int defaultCost;


    public int SecondsToLive;
    protected int defaultSecondsToLive;
    private int secondsToLive
    {
        get
        {
            return SecondsToLive > 0 ? SecondsToLive : defaultSecondsToLive;
        }
    }
    private DateTime? liveTo;


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
        if (liveTo < DateTime.Now)
        {
            liveTo = null;
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
        Debug.LogFormat("Start {0}", gameObject.name);
        liveTo = DateTime.Now.AddSeconds(secondsToLive);
    }

    void OnDisable()
    {
        liveTo = null;
    }

    void OnTriggerEnter(Collider col)
    {
        Debug.Log(string.Format("Trigger with terrain and {0} {1}", col.gameObject.transform.parent.transform.parent.name, col.gameObject.transform.parent.transform.parent.tag));
        if (col.gameObject.transform.parent.transform.parent.tag == "Player" && liveTo == null)
        {
            liveTo = DateTime.Now.AddSeconds(secondsToLive);
        }
    }
    
}
