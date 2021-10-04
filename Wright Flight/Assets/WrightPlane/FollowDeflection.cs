using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(ControlSurface))]
public class FollowDeflection : MonoBehaviour
{
    private ControlSurface ctrlsfs;
    public ControlSurface followedSurface;
    private void Awake()
    {
        ctrlsfs = GetComponent<ControlSurface>();
    }


    // Update is called once per frame
    void Update()
    {
        ctrlsfs.targetDeflection = followedSurface.targetDeflection;
    }
}
