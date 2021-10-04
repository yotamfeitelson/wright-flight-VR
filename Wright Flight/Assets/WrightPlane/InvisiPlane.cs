using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisiPlane : MonoBehaviour
{
    public string tag_stays_visible = "Player"; 
    void OnEnable()
    {
        foreach (Renderer r in GetComponentsInChildren<Renderer>())
        {
            r.enabled = false;
        }
        foreach (Transform child in transform)
        {
            if (child.gameObject.tag == tag_stays_visible)
            {
                foreach (Renderer r in child.GetComponentsInChildren<Renderer>())
                {
                    r.enabled = true;
                }
            }
        }
    }
    void OnDisable()
    {
        foreach (Renderer r in GetComponentsInChildren<Renderer>())
        {
            r.enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
