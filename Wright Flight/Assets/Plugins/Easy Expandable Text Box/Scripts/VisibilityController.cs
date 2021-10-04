using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteAlways]
public class VisibilityController : MonoBehaviour
{
 
    private void Awake()
    {
        transform.GetChild(0).hideFlags = HideFlags.HideInHierarchy;
        GetComponent<VisibilityController>().hideFlags = HideFlags.HideInInspector;
        GetComponent<VerticalLayoutGroup>().hideFlags = HideFlags.HideInInspector;
    }

    private void Update()
    {
        
    }
}
