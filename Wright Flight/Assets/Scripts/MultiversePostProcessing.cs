using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MultiversePostProcessing : MonoBehaviour
{
    void Awake()
    {
        EventManager.Instance.OnMultiverse += OnMultiverse;
       
    }

    public void OnMultiverse()
    {
        foreach (Transform t in GetComponentsInChildren<Transform>(true))
        {
            t.gameObject.SetActive(true);
        }
        StartCoroutine(EndGame());
    }
    IEnumerator<UnityEngine.WaitForSeconds> EndGame()
    {
        Debug.Log("Started 5secs");
        yield return new WaitForSeconds(15);
        Debug.Log("Ended 5secs");
        EventManager.Instance.EndGame();
        //SceneManager.LoadScene("end scene");
    }
}
