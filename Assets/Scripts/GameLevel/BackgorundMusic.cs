using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgorundMusic : MonoBehaviour
{
    private AudioSource audioSrc;
    private float musicVolume = 1f;
    
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }
    
    void Update()
    {
        audioSrc.volume = musicVolume;
    }

    public void SetVolume(float vol)
    {
        musicVolume = vol;
    }
}
