using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    //Sesleri çalma, durdurma işlemlerini yapan sınıf.

    public static AudioController instance { get; private set; }

    /*void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }*/

    //private void Play() {}
    //private void Resume() {}
    //private void Pause() {}
    //private void Stop() {}

}
