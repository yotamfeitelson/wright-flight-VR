using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartFlight : MonoBehaviour
{
    public void InitiateTakeoff()
    {
        Debug.Log("Initiating takeoff!");
        EventManager.Instance.TakeOff();
    }
}
