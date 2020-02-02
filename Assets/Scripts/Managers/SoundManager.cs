using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    //Enum with the modificable parameters
    public enum SoundParameters { test}
    public enum SoundEvent { test }

    public enum SoundState {Fondo, Arm, Mel}
    private string [] stateNames = { "Fondo", "Arm", "Mel" };
    private int currentState = 1;

    public static SoundManager instance = null;                //Static instance of GameManager which allows it to be accessed by any other script.

    //Awake is always called before any Start functions
    void Awake()
    {
        //Check if instance already exists
        if (instance == null)

            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);

        AkSoundEngine.SetSwitch("Music", stateNames[currentState], gameObject);
        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        AkSoundEngine.PostEvent("MusicOn", gameObject);
    }

    /// <summary>
    /// Sets the parameter with the given value. 
    /// You can only use parameters defined in the enum SoundEvent
    /// </summary>
    /// <param name="nombreParametro">Name of the parameter you want to modify</param>
    /// <param name="valor">value that the parameter will be modified to</param>
    public void SetRTCPValue(SoundEvent nombreParametro, int valor)
    {
        AkSoundEngine.SetRTPCValue(nombreParametro.ToString(), valor);
    }

    public void ChangeState (int state)
    {
        if(currentState != state)
        {
            currentState = Mathf.Clamp(state, 0, 2);
            AkSoundEngine.SetSwitch("Music",stateNames[currentState], gameObject);
        }
    }

    public void Sentarse()
    {
        AkSoundEngine.SetSwitch("Music", stateNames[Mathf.Clamp(currentState+1, 0,  2)], gameObject);
    }

    public void Levantarse()
    {
        AkSoundEngine.SetSwitch("Music", stateNames[currentState], gameObject);
    }
}
