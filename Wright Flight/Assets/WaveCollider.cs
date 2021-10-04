using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveCollider : MonoBehaviour
{
    public WrightbrotherAnimScript wbas;
    private bool wave1 = false;
    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Respawn")
        {
            if (!wave1)
            {
                wbas.num = 3;
                wave1 = true;
            }
            else
            {
                wbas.num = 5;
                this.gameObject.SetActive(false);
            }
        }
    }
}
