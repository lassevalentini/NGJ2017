using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GoldUpdater : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = GameState.Instance.GetGold().ToString();
    }
}
