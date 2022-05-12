using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    [Range(0f, 1f)]
    public float masterVolume = 1f;

    public AudioMixerGroup music;
    public AudioMixerGroup sfx;

    public Sound[] sounds;

    public static AudioManager instance;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);               
        }

        AudioListener.volume = masterVolume;

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();

            s.source.clip = s.clip;            
            s.source.loop = s.loop;
            
            switch (s.soundType)
            {
                case Sound.SoundType.Music:
                    s.source.outputAudioMixerGroup = music;
                    break;
                case Sound.SoundType.Sfx:
                    s.source.outputAudioMixerGroup = sfx;
                    break;
                default:
                    break;
            }
        }
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, item => item.name == name);
        if (s == null)
        {
            Debug.Log($"Sound \"{name}\" was not found!");
            return;
        }

        s.source.volume = s.volume;
        s.source.pitch = s.pitch;

        s.source.Play();
    }
    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, item => item.name == name);
        if (s == null)
        {
            Debug.Log($"Sound \"{name}\" was not found!");
            return;
        }
        s.source.Stop();
    }    
}