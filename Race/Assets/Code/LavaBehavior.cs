using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaBehavior : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider col)
    {
        Debug.Log(string.Format("Trigger with lava and {0} {1}", col.gameObject.name, col.gameObject.tag));
        if (col.gameObject.transform.parent.transform.parent.tag == "Player")
        {
            GameState.Instance.EndGame();
        }
    }
    
}
