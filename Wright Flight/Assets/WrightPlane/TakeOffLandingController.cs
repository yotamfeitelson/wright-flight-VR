using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
// Takes care of takeoff and landing, canbe called from outside. will replace pusher
public class TakeOffLandingController : MonoBehaviour
{
    public Rigidbody rb;
    public Engine engine;
    public Pusher pusher;
    public AudioSource audioSource;
    private bool endHappened = false;
    [SerializeField] WheelCollider[] wheels = new WheelCollider[3];

    private bool takeoffInitiated = false;
    // Start is called before the first frame update
    void Awake()
    {
        if (rb == null)  rb = GetComponent<Rigidbody>();
        if (engine == null) engine = GetComponent<Engine>();
        if (pusher == null) pusher = GetComponent<Pusher>();
        if (audioSource == null) audioSource = GetComponent<AudioSource>();
        EventManager.Instance.OnTakeOff += OnTakeOff;
        EventManager.Instance.OnLand += OnLand;
        EventManager.Instance.OnCrash += OnCrash;
       

    }
    private void OnDestroy()
    {
        EventManager.Instance.OnTakeOff -= OnTakeOff;
        EventManager.Instance.OnLand -= OnLand;
        EventManager.Instance.OnCrash -= OnCrash;
    }

    private void Update()
    {
        if(pusher.enabled == false && takeoffInitiated)
        {
            WheelHit hit = new WheelHit();
            foreach (WheelCollider w in wheels)
            {                
                if (!w.GetGroundHit(out hit))
                {
                    return;
                }
            }
            if(true||hit.collider.tag == "Terrain")
            {
                Debug.Log("landed successfully");
                EventManager.Instance.Land();
            }

        }
    }

    public void OnTakeOff()
    {
        if (rb.isKinematic)
        {
            rb.isKinematic = false;
        }
        engine.throttle = 1;
        pusher.enabled = true;
        takeoffInitiated = true;
        audioSource.enabled = true;
       
    }

   
    // Update is called once per frame
    
    public void OnLand()
    {
        audioSource.enabled = false;
        engine.throttle = 0;
        pusher.enabled = false;
        //StartCoroutine(EndGame());
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Brother")
        {
            EventManager.Instance.CrashOnBro();
            endHappened = true;
        }
        if (collision.gameObject.layer != 6 && !endHappened)
        {
            EventManager.Instance.Crash();
        }
    }

    public void OnCrash()
    {
        audioSource.enabled = false;
        Debug.Log("Crashing!");
        Transform[] childArray = GetComponentsInChildren<Transform>(true);
        foreach(Transform child in childArray)
        {
            GameObject child_go = child.gameObject;
            if (child_go.GetComponent<Renderer>()!=null && child_go.GetComponent<Renderer>().enabled)
            {
                child.SetParent(null);
                child_go.AddComponent(typeof(BoxCollider));
                child_go.AddComponent(typeof(Rigidbody));
            }
        }
        engine.throttle = 0;
        pusher.enabled = false;
        //StartCoroutine(EndGame());

    }
    IEnumerator<UnityEngine.WaitForSeconds> EndGame()
    {
        Debug.Log("Started 5secs");
        yield return new WaitForSeconds(5);
        Debug.Log("Ended 5secs");
        EventManager.Instance.EndGame();
    }
}
