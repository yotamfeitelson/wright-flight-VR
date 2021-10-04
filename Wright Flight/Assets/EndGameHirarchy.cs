using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameHirarchy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        EventManager.Instance.OnEndGame += OnEndGame;
    }

    void OnEndGame()
    {
        transform.parent = null;
        transform.position = Vector3.zero;
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}
