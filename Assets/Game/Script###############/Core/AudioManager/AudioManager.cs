using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    [Header("Audio Sources")]
    public AudioSource bgmSource;
    public AudioSource sfxSource;

    [Header("Audio Clips")]
    public List<AudioClip> bgmClips;
    public List<SoundData> sfxList;

    private Dictionary<string, AudioClip> sfxDict = new Dictionary<string, AudioClip>();

    private const string VOLUME_BGM_KEY = "volume_bgm";
    private const string VOLUME_SFX_KEY = "volume_sfx";

    protected new void Awake()
    {
        base.Awake(); // Gọi hàm Awake() của Singleton<T>
        
        foreach (SoundData data in sfxList)
        {
            if (!sfxDict.ContainsKey(data.name))
            {
                sfxDict.Add(data.name, data.clip);
            }
        }

        // Load volume settings
        SetBGMVolume(PlayerPrefs.GetFloat(VOLUME_BGM_KEY, 1f));
        SetSFXVolume(PlayerPrefs.GetFloat(VOLUME_SFX_KEY, 1f));
    }

    #region BGM

    public void PlayBGM(int index, bool loop = true)
    {
        if (index >= 0 && index < bgmClips.Count)
        {
            bgmSource.clip = bgmClips[index];
            bgmSource.loop = loop;
            bgmSource.Play();
        }
        else
        {
            Debug.LogWarning("AudioManager: Invalid BGM index.");
        }
    }

    public void StopBGM()
    {
        bgmSource.Stop();
    }

    public void SetBGMVolume(float volume)
    {
        bgmSource.volume = volume;
        PlayerPrefs.SetFloat(VOLUME_BGM_KEY, volume);
    }

    #endregion

    #region SFX

    public void PlaySFX(string name)
    {
        if (sfxDict.ContainsKey(name))
        {
            sfxSource.PlayOneShot(sfxDict[name]);
        }
        else
        {
            Debug.LogWarning("AudioManager: SFX not found - " + name);
        }
    }

    public void SetSFXVolume(float volume)
    {
        sfxSource.volume = volume;
        PlayerPrefs.SetFloat(VOLUME_SFX_KEY, volume);
    }

    #endregion
}

[System.Serializable]
public class SoundData
{
    public string name;
    public AudioClip clip;
}
