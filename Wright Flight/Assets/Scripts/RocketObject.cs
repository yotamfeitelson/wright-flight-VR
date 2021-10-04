using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketObject : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {

        Debug.Log("Hit player!");
        EventManager.Instance.Rocket();
        this.gameObject.SetActive(false);

    }
}
