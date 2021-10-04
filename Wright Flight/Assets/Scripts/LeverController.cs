using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverController : MonoBehaviour
{
    [SerializeField] GameObject obj;
    public float getVal()
    {
        float retval = obj.transform.localEulerAngles.x;
       if(retval > 180)
        {
            return (retval - 360) / 45f;
        }
        return retval / 45f;

    }
}
