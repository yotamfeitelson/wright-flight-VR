using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canvas : MonoBehaviour
{

    public GameObject crash;
    public GameObject land;
    public GameObject crashOnBro;
    public GameObject Rocket;
    public GameObject Multiverse;
    private GameObject[] canvases;
    int active_event=-1;



    protected void Awake()
    {
        EventManager.Instance.OnCrash += OnCrash;
        EventManager.Instance.OnCrashOnBro += OnCrashOnBro;
        EventManager.Instance.OnMultiverse += OnMultiverse;
        EventManager.Instance.OnRocket += OnRocket;
        EventManager.Instance.OnLand += OnLand;
        canvases = new GameObject[] { crash, land, crashOnBro, Rocket, Multiverse };
    }

    protected void OnDestroy()
    {
        EventManager.Instance.OnCrash -= OnCrash;
        EventManager.Instance.OnCrashOnBro -= OnCrashOnBro;
        EventManager.Instance.OnMultiverse -= OnMultiverse;
        EventManager.Instance.OnRocket -= OnRocket;
        EventManager.Instance.OnLand -= OnLand;
    }

    private void OnCrash()
    {
        if (active_event < 0)
        {
            active_event = 0;
            StartCoroutine(Wait5Secs());
        }
    }

    private void OnLand()
    {
        if (active_event < 0)
        {
            active_event = 1;
            StartCoroutine(Wait5Secs());
        }
    }

    private void OnCrashOnBro()
    {
        if (active_event < 0)
        {
            active_event = 2;
            StartCoroutine(Wait5Secs());
        }
    }

    private void OnRocket()
    {
        
    }

    private void OnMultiverse()
    {
        if (active_event < 0)
        {
            active_event = 4;
            StartCoroutine(Wait15Secs());
        }
    }

    IEnumerator Wait5Secs()
    {
        yield return new WaitForSeconds(5);
        canvases[active_event].SetActive(true);
        EventManager.Instance.EndGame();

    }
    IEnumerator Wait15Secs()
    {
        yield return new WaitForSeconds(15);
        canvases[active_event].SetActive(true);
        EventManager.Instance.EndGame();
    }




}
