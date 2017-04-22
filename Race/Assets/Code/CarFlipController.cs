using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Vehicles.Car;

public class CarFlipController : MonoBehaviour
{

    private CarController m_Car; // the car controller we want to use


    private void Awake()
    {
        // get the car controller
        m_Car = GetComponent<CarController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (CrossPlatformInputManager.GetButtonDown("Flip Car"))
        {


            var oldpos = m_Car.transform.position;
            m_Car.transform.rotation = Quaternion.identity;
            m_Car.transform.Rotate(0, 90, 0);
            m_Car.transform.position = oldpos + new Vector3(0, 4, 0);
            GameState.Instance.LastTouchedTerrain.LiveTo -= TimeSpan.FromSeconds(2);
        }
    }
}
