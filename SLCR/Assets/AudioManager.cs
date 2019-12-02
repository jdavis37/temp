using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public Sound[] sounds;
    // Start is called before the first frame update
    void Awake()
    {
        foreach (Sound s in sounds) ////loops
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }
    void Start()
    {
        // Play("Theme");
        // Play("safe");
        //Play("battle2");
        Play("safe");

        Invoke("playAudio", 62f);
        // function PlayNextTrack
        // audio.Stop(); // just in case
    }

    void playAudio()
    {
        // s.source.Stop();
        Play("battle1");
    }
    // Update is called once per frame
    public void Play(string name)
    {

        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();

    }
}
