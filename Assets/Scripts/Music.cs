using UnityEngine;
using UnityEngine.InputSystem;

public class Music : MonoBehaviour
{
    AudioSource audioPlayer;
    int i = 0;
    Object[] music;
    bool hasStopped = true;
    float maxVol = 0.4f;

    public bool HasStopped()
    {
        return hasStopped;
    }

    public float GetVolume()
    {
        return audioPlayer.volume;
    }

    public int GetSong()
    {
        return i + 1;
    }

    public float GetTime()
    {
        return audioPlayer.time;
    }
    
    void Awake()
    {
        audioPlayer = GetComponent<AudioSource>();
        audioPlayer.volume = maxVol;
        music = Resources.LoadAll("Music", typeof(AudioClip));
        audioPlayer.clip = music[i] as AudioClip;
    }

    void Update()
    {
        if (!hasStopped && !audioPlayer.isPlaying)
        {
            PlayNext();
        }
    }

    void PlayNext()
    {
        i++;
        if (i == music.Length) i = 0;
        Debug.Log(i);
        audioPlayer.clip = music[i] as AudioClip;
        
        if (!hasStopped)
        {
            audioPlayer.Play();
        }
        
    }

    void PlayPrev()
    {
        i--;
        if (i < 0) i = music.Length - 1;
        Debug.Log(i);
        audioPlayer.clip = music[i] as AudioClip;

        if (!hasStopped)
        {
            audioPlayer.Play();
        }

    }

    public void OnPlayNext(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            PlayNext();
        }
    }

    public void OnPlayPrev(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            PlayPrev();
        }
    }

    public void Play(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            hasStopped = !hasStopped;
            Debug.Log(audioPlayer.clip.length + " time: " + audioPlayer.time);
            if (!audioPlayer.isPlaying)
            {
                audioPlayer.Play();
            }
            else
            {
                audioPlayer.Pause();
            }
        }
        
    }

    public void OnChangeVolume(InputAction.CallbackContext context)
    {
        audioPlayer.volume = Mathf.Clamp(audioPlayer.volume + context.ReadValue<float>() * 0.02f, 0, maxVol);
    }
}
