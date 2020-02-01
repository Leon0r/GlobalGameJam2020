using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    //Enum with the modificable parameters
    public enum SoundParameters { test}
    public enum SoundEvent { test }

    //TODO: De momento es un singleton, pero es posible que no queramos que lo sea!

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

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
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

}
