using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    //Enum with the modificable parameters
    public enum SoundParameters { test}
    public enum SoundEvent { test }


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
