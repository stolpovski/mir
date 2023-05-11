using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Params : MonoBehaviour
{
    public Music music;
    TMP_Text textmeshPro;
    GameObject cosmonaunt;
    Light f;
    // Start is called before the first frame update
    void Start()
    {
        textmeshPro = GetComponent<TMP_Text>();
        cosmonaunt = GameObject.Find("Cosmonaut");

        f = cosmonaunt.GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        string fl = f.enabled ? "¬ À" : "¬€ À";
        string isPlaying = music.HasStopped() ? "¬€ À" : "¬ À";
        float vol = music.GetVolume();
        int song = music.GetSong();
        float time = music.GetTime();

        textmeshPro.SetText(fl + "\n" + isPlaying + "\n{0:.00}\n{1}\n{2:.00}", vol, song, time);
    }
}
