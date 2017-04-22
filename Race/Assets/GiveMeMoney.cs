using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveMeMoney : MonoBehaviour {

    private int MoneyOnPowerUp = 60;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "CarBumper")
        {
            Debug.Log("The player has picked up the resource!");
            Destroy(gameObject);
            GameState.Instance.Gold += MoneyOnPowerUp;
        }
            
        

    }
}
