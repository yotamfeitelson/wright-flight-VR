using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pusher : MonoBehaviour
{
    public float pushForce = 10000f;
    public float pushTime = 6f;
    private bool push;
    public Rigidbody rb;
    // Start is called before the first frame update
    void OnEnable()
    {
        if(rb == null)
        {
            rb = GetComponent<Rigidbody>();
        }
        StartCoroutine(TakeOff());
    }

    IEnumerator TakeOff()
    {
        push = true;

        yield return new WaitForSeconds(pushTime);

        push = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (push) {
            Debug.Log("Pushing");
            rb.AddRelativeForce(transform.forward*pushForce, ForceMode.Force);
                }
        else
        {
            Debug.Log("Stopped Pushing");
            enabled = false;
        }
    }
}
