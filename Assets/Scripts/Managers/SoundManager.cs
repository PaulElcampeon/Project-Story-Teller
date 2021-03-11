using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [Header("Sound Effect Sounds")]
    [SerializeField]
    private AudioSource[] _sfxSounds;

    [Header("Back Ground Music Sounds")]
    [SerializeField]
    private AudioSource[] _bgmSounds;

    public float sfxVolume { get; set; }
    public float bgmVolume { get; set; }

    public static SoundManager INSTANCE;

    private void Awake()
    {
        DontDestroyOnLoad(this);

        if (INSTANCE == null)
        {
            INSTANCE = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        sfxVolume = 0.4f;
        bgmVolume = 0.3f;
    }

    public void PlaySFX(int sfxIndex)
    {
        AudioSource sound = _sfxSounds[sfxIndex];

        sound.volume = sfxVolume;
        sound.Play();
    }

    public void PlayBGM(int bgmIndex)
    {
        AudioSource sound = _bgmSounds[bgmIndex];

        sound.volume = bgmVolume;
        sound.Play();
    }

    public void StopCurrentBGM()
    {
        for (int i = 0; i < _bgmSounds.Length; i++)
        {
            if (_bgmSounds[i].isPlaying) _bgmSounds[i].Stop();
        }
    }

    public void UpdateBGMVolume(float volume)
    {
        for (int i = 0; i < _bgmSounds.Length; i++)
        {
            _bgmSounds[i].volume = volume;
        }
    }

    public void UpdateSFXVolume(float volume)
    {
        sfxVolume = volume;
    }
}
