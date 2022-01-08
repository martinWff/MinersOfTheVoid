using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public AudioMixer audioMixer;
    public static SettingsManager instance;


    private Dictionary<string, float> cachedVolume = new Dictionary<string, float>(3);
    // Start is called before the first frame update

    private void Awake()
    {
        if (instance == null) {
            instance = this;


            LoadSettings();
        }
    }

    public void LoadSettings()
    {
        Debug.Log("loaded settings");
        Debug.Log(PlayerPrefs.GetFloat("masterVolume", GetLinearVolume("masterVolume")));
        SetVolume("masterVolume",PlayerPrefs.GetFloat("masterVolume", GetLinearVolume("masterVolume")));
        SetVolume("sfxVolume", PlayerPrefs.GetFloat("sfxVolume", GetLinearVolume("sfxVolume")));
        SetVolume("bgmVolume", PlayerPrefs.GetFloat("bgmVolume", GetLinearVolume("bgmVolume")));
    }

    public void SaveSettings()
    {
        PlayerPrefs.SetFloat("masterVolume", SettingsManager.instance.GetLinearVolume("masterVolume"));
        PlayerPrefs.SetFloat("bgmVolume", SettingsManager.instance.GetLinearVolume("bgmVolume"));
        PlayerPrefs.SetFloat("sfxVolume", SettingsManager.instance.GetLinearVolume("sfxVolume"));
        PlayerPrefs.Save();
    }

    public bool SetVolume(string channel, float volume)
    {
       float v = Mathf.Log10(volume) * 20;
        return audioMixer.SetFloat(channel, v);
    }

    public bool SetVolumeDecibel(string channel, float volume)
    {
        return audioMixer.SetFloat(channel, volume); 
    }

    public float GetVolume(string channel)
    {
        float v = 0;
        if (audioMixer.GetFloat(channel, out v)) {
            return v;
        }
        return v;
    }

    public float GetLinearVolume(string channel) {

        return DecibelToLinear(GetVolume(channel));

    }

    public float GetSavedValue(string channel)
    {
        if (!cachedVolume.ContainsKey(channel))
        {
            float f = PlayerPrefs.GetFloat(channel, GetLinearVolume(channel));
            cachedVolume.Add(channel, f);
            return f;
        } else
        {
            return cachedVolume[channel];
        }
    }
    


    public float DecibelToLinear(float dB)
    {
        float linear = Mathf.Pow(10.0f, dB / 20.0f);

        return linear;
    }



}
