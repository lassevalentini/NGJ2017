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

    void OnCollisionEnter(Collision col)
    {
        Debug.Log(string.Format("Collision with {0}", col.gameObject));
        if (col.gameObject.tag == "Player")
        {
            GameState.EndGame();
        }
    }
}
