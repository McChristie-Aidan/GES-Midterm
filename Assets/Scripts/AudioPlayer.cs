using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioPlayer : MonoBehaviour
{
    AudioSource audio;
    public bool playOnStart = false;
    public AudioClip clip;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        clip = audio.clip;
        if (playOnStart == true)
        {
            audio.Play(0);
        }
    }

    public void PlayAudio()
    {
        audio.Play(0);
    }
}
