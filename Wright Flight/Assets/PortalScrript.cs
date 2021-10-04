using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalScrript : MonoBehaviour
{
    public AudioSource audioSource;
    private void OnTriggerEnter(Collider other)
    {

        Debug.Log("Hit player!");
        EventManager.Instance.Multiverse();
        audioSource.enabled = true;


    }
}
