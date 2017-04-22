using UnityEngine;
using System.Collections;
using System;

public abstract class TerrainBase : MonoBehaviour
{
    protected int secondsToLive;
    private DateTime? liveTo;


    // Use this for initialization
    void Start()
    {
        Init();
        Debug.LogFormat("Start {0}", gameObject.name);
        liveTo = DateTime.Now.AddSeconds(secondsToLive);
    }

    protected virtual void Init()
    {
        secondsToLive = 10;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (liveTo < DateTime.Now)
        {
            liveTo = null;
            Debug.LogFormat("{0} shouldnt live", gameObject.name);
            PrefabFactory.Instance.TerrainManager.RecyclePrefab(gameObject);
        }
    }

    void OnEnable()
    {
        Debug.LogFormat("Enabling {0}", gameObject.name);
        //liveTo = DateTime.Now.AddSeconds(secondsToLive);
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
