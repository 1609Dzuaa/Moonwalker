using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameEnums;

public class SoundsManager : Singleton<SoundsManager>
{
    [SerializeField]
    Sound[] sfxSounds, musicSounds;
    [SerializeField] AudioSource _sfxSource, _musicSource;

    public override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        PlayMusic(ESoundName.StartScreen);
    }

    public void PlayMusic(ESoundName soundName)
    {
        Sound s = Array.Find(musicSounds, x => x._name == soundName);

        if (s == null)
            Debug.Log("Sound Not Found");
        else
        {
            _musicSource.clip = s._audioClip;
            _musicSource.Play();
        }
    }

    public void PlaySFX(ESoundName name)
    {
        Sound s = Array.Find(sfxSounds, x => x._name == name);

        if (s == null)
            Debug.Log("Sound Not Found");
        else
            _sfxSource.PlayOneShot(s._audioClip);
    }

}
