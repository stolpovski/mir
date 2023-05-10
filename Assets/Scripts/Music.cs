using UnityEngine;

public class Music : MonoBehaviour
{
    new AudioSource audio;
    int i = 0;
    Object[] music;
    
    void Awake()
    {
        audio = GetComponent<AudioSource>();
        music = Resources.LoadAll("Music", typeof(AudioClip));
    }

    private void Start()
    {
        PlayNext();
    }

    void Update()
    {
        if (!audio.isPlaying)
        {
            PlayNext();
        }
    }

    void PlayNext()
    {
        if (i == music.Length) i = 0;
        audio.clip = music[i] as AudioClip;
        audio.Play();
        i++;
    }
}
