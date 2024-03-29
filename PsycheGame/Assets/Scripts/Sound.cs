﻿using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
    public bool loop;
    
    [Range(0f, 1f)]
    public float volume;

    [HideInInspector]
    public AudioSource source;
}
