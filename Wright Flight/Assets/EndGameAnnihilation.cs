using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameAnnihilation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        EventManager.Instance.OnEndGame += OnEndGame;
    }

    void OnEndGame()
    {
        foreach(GameObject g in GameObject.FindObjectsOfType(typeof(GameObject)))
        {
            if (g.layer != 7)
            {
                g.SetActive(false);
            }
        }
    }
}
