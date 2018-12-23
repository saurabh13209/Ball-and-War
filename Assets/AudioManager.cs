using UnityEngine;
using System;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour {

    public Sound[] sounds;
    public static AudioManager instance;

    public static Sound MainBackgroundSound;
    private static bool isPlaying = true;

	// Use this for initialization
	void Awake () {

        if (instance == null)
        {
            instance = this;
        }
        else {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds) {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
	}

    public void Start()
    {
        Play("BackgroundMusic");
       
    }
    

    public void StopMain() {
        if (isPlaying) {
            MainBackgroundSound.source.Stop();
            isPlaying = false;
        }
        else
        {
            MainBackgroundSound.source.Play();
            isPlaying = true;
        }
    }

    public void Play(string name) {
        if (name == "BackgroundMusic") {
            MainBackgroundSound =  Array.Find(sounds, sound => sound.name == name);
            MainBackgroundSound.source.Play();
        }
        else {
            Sound s = Array.Find(sounds, sound => sound.name == name);
            s.source.Play();
        }
    }
}
