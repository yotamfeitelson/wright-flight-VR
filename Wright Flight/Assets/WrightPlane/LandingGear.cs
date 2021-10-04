using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandingGear : MonoBehaviour
{
    public WheelCollider wc;
    private void Start()
    {
        if (wc == null)
        {
            wc = GetComponent<WheelCollider>();
        }
    }

    private void Update()
    {
        WheelHit wh;
        if (wc.GetGroundHit(out wh))
        {
            if (wh.collider.tag == "Finish")
                Debug.Log("wheel hit");
        }
    }
    
}
