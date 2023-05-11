using UnityEngine;
using UnityEngine.InputSystem;

public class Music : MonoBehaviour
{
    new AudioSource audio;
    int i = 0;
    Object[] music;
    bool hasStopped = true;
    float maxVol = 0.4f;
    
    void Awake()
    {
        audio = GetComponent<AudioSource>();
        audio.volume = maxVol;
        music = Resources.LoadAll("Music", typeof(AudioClip));
        audio.clip = music[i] as AudioClip;
    }

    private void Start()
    {
        //PlayNext();
    }

    void Update()
    {
        if (!hasStopped && !audio.isPlaying)
        {
            PlayNext();
        }
    }

    void PlayNext()
    {
        i++;
        if (i == music.Length) i = 0;
        Debug.Log(i);
        audio.clip = music[i] as AudioClip;
        
        if (!hasStopped)
        {
            audio.Play();
        }
        
    }

    void PlayPrev()
    {
        i--;
        if (i < 0) i = music.Length - 1;
        Debug.Log(i);
        audio.clip = music[i] as AudioClip;

        if (!hasStopped)
        {
            audio.Play();
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
            Debug.Log(audio.clip.length + " time: " + audio.time);
            if (!audio.isPlaying)
            {
                audio.Play();
            }
            else
            {
                audio.Pause();
            }
        }
        
    }

    public void OnChangeVolume(InputAction.CallbackContext context)
    {
        audio.volume = Mathf.Clamp(audio.volume + context.ReadValue<float>() * 0.02f, 0, maxVol);
    }
}
