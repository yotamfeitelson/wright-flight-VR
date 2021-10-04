using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public enum Events
{
    Crash,
    CrashOnBro,
    Rocket,
    Multiverse,
    Land,
    TakeOff,
    EndGame
}

public class EventManager
{

    Boolean isRocket = false;

    private List<Events> events = new List<Events>();

    private static readonly EventManager instance = new EventManager();

    // Explicit static constructor to tell C# compiler
    // not to mark type as beforefieldinit
    static EventManager()
    {
    }

    private EventManager()
    {
    }

    public static EventManager Instance
    {
        get
        {
            return instance;
        }
    }

    public event Action OnCrash;
    public event Action OnCrashOnBro;
    public event Action OnRocket;
    public event Action OnMultiverse;
    public event Action OnLand;
    public event Action OnEndGame;

    IEnumerator<UnityEngine.WaitForSeconds> WaitSecs()
    {
        Debug.Log("Started 5secs");
        yield return new WaitForSeconds(5);
        Debug.Log("Ended 5secs");
        SceneManager.LoadScene("end scene");
    }

    public void Crash()
    {
        events.Add(Events.Crash);
        OnCrash?.Invoke();
        //SceneManager.LoadScene("end scene");
    }

    
    public void Land()
    {
        events.Add(Events.Land);
        OnLand?.Invoke();
        //SceneManager.LoadScene("end scene");
        //SceneManager.LoadScene("end scene");
    }

    public void CrashOnBro()
    {
        events.Add(Events.CrashOnBro);
        OnCrashOnBro?.Invoke();
        //SceneManager.LoadScene("end scene");
    }

    public void Rocket()
    {
        events.Add(Events.Rocket);
        OnRocket?.Invoke();
        isRocket = true;
    }

    public void Multiverse()
    {
        Debug.Log("Multiverse invoked");
        events.Add(Events.Multiverse);
        OnMultiverse?.Invoke();
        //SceneManager.LoadScene("end scene");
    }

    public event Action OnTakeOff;

    public void TakeOff()
    {
        events.Add(Events.TakeOff);
        OnTakeOff?.Invoke();
    }
    public void EndGame()
    {
        events.Add(Events.EndGame);
        OnEndGame?.Invoke();
    }

}
