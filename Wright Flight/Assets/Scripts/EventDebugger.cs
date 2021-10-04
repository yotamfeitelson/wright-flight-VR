using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventDebugger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
       
        Debug.Log("Hit player!");
        EventManager.Instance.Multiverse();

       
    }
}
