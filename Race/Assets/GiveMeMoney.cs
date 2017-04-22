using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveMeMoney : MonoBehaviour {

    public int MoneyOnPowerUp = 100;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("The player has picked up the resource!");
        GameState.Instance.Gold += MoneyOnPowerUp;
        Destroy(gameObject);
    }
}
