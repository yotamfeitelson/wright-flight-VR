using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketController : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip rocketStartSound;
    public AudioClip rocketLoopSound;
    public GameObject smokeTrail;
    public Engine engine;
    // Start is called before the first frame update
    void Start()
    {
        if (audioSource == null) audioSource = GetComponent<AudioSource>();
        if (engine == null) engine = GetComponent<Engine>();
        EventManager.Instance.OnRocket += OnRocket;
    }
    private void OnDestroy()
    {
        EventManager.Instance.OnRocket -= OnRocket;
    }

    private void OnRocket()
    {
        engine.thrust = 6000;

        smokeTrail.SetActive(true);
        StartCoroutine(playEngineSound());
    }
    IEnumerator playEngineSound()
    {
        audioSource.clip = rocketStartSound;
        audioSource.Play();
        yield return new WaitForSeconds(audioSource.clip.length);
        audioSource.clip = rocketLoopSound;
        audioSource.Play();
    }
}
