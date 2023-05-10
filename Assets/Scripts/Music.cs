using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    new AudioSource audio;
    int i = 0;
    Object[] music;
    // Start is called before the first frame update
    void Awake()
    {
        audio = GetComponent<AudioSource>();
        music = Resources.LoadAll("Music", typeof(AudioClip));
        
    }

    private void Start()
    {
        PlayAudio(i);
    }

    // Update is called once per frame
    void Update()
    {
        if (!audio.isPlaying)
        {
            PlayAudio(++i);
        }
    }

    void PlayAudio(int i)
    {
        if (i == music.Length) i = 0;
        audio.clip = music[i] as AudioClip;
        audio.Play();
    }
}
