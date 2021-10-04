using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrightbrotherAnimScript : MonoBehaviour
{
    public Animator animator;
    private bool startedExplanation;
    public int num;
    public AudioSource audioSource;
    public EasyExpandableTextBox textBox;
    public AudioClip bonVoyageAudioClip;
    public AudioClip deathClip;
    public string startGame = "Wave in the green box to start!";
    public string explanation = "Hello brother! Rememeber! Use the left stick to tilt the plane up and down, " +
        "\n and use your waist to move the plane left and right!\n" +
        "Wave again to take off!";
    public string takeoffText = "Bon Voyage! \n Just don't land on me hahaha! :D";
    // Start is called before the first frame update
    void Start()
    {

        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
        textBox.EasyMessage(startGame, 0.07f);
    }

    // Update is called once per frame
    void Update()
    {
        if (num == 3)
        {
            animator.SetTrigger("startexplain");
            num = 0;
            audioSource.enabled = true;
            startedExplanation = true;
            textBox.EasyMessage(explanation, 0.07f);
        }
        if (num == 5)
        {
            animator.SetTrigger("bonvoyage");
            num = 0;
            Debug.Log("bon voyage");
            textBox.EasyMessage(takeoffText, 0.07f);
            audioSource.clip = bonVoyageAudioClip;
            audioSource.loop = false;
            audioSource.Play();
            StartCoroutine(WaitSecs());
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (this.gameObject.layer == 0)
        {
            EventManager.Instance.CrashOnBro();
            audioSource.clip = deathClip;
            audioSource.loop = false;
            audioSource.Play();
            this.gameObject.AddComponent(typeof(Rigidbody));
            GetComponent<Collider>().isTrigger = false;
        }
    }
    IEnumerator WaitSecs()
    {
        yield return new WaitForSeconds(bonVoyageAudioClip.length);
        //audioSource.enabled = false;
        EventManager.Instance.TakeOff();
    }
    IEnumerator ColliderWait()
    {
        yield return new WaitForSeconds(5);
        this.gameObject.layer = 0;
    }
}
