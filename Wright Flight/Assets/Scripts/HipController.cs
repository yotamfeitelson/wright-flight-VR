using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HipController : MonoBehaviour
{
    [SerializeField]    GameObject trackedHip;
    [SerializeField]    GameObject leftBound;
    [SerializeField]    GameObject rightBound;
    //void Update()
    //{
    //    if(trackedHip.transform.localPosition.x< rightBound.transform.localPosition.x &&
    //        trackedHip.transform.localPosition.x > rightBound.transform.localPosition.x){
    //        transform.position.x = trackedHip.transform.localPosition.x;
    //    }
    //}


    public float getVal()
    {
        float retval = 0;
       
            //Debug.Log("Tracked Hip: " + trackedHip.transform.localPosition.x);
            if (trackedHip.transform.localPosition.x < rightBound.transform.localPosition.x &&
               trackedHip.transform.localPosition.x > leftBound.transform.localPosition.x)
            {
                retval = trackedHip.transform.localPosition.x / rightBound.transform.localPosition.x;
            }
            return retval;
        
    }
}
