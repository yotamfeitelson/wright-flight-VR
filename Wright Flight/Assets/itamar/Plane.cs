using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    protected void Awake()
    {
        //EventManager.Instance.OnCrash += OnCrash;
    }

    protected void OnDestroy()
    {
        //EventManager.Instance.OnCrash -= OnCrash;
    }

    private void OnCrash(List<Vector3> data)
    {
        //do something.
    }

    private void HealthReachedZero()
    {
        //EventManager.Instance.Crash(new List<Vector3>());
    }
}
