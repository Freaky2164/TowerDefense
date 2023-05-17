using System.Collections;
using System.Collections.Generic;
using GameHandling;
using UnityEngine;

public class MusicScript : MonoBehaviour
{
    private static MusicScript instance;

    private void Awake()
    {
        JsonFileHandler.Start();
        if (JsonFileHandler.PlayerSettings.muteMusic) Mute();
        else Play();
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this);
    }
    
    public void Mute()
    { 
        GetComponent<AudioSource>().Stop();
    }

    public void Play()
    {
        GetComponent<AudioSource>().Play();
    }
}
