using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsUIController : MonoBehaviour
{

    public SoundSliderElement masterSlider;
    public SoundSliderElement bgmSlider;
    public SoundSliderElement sfxSlider;
    // Start is called before the first frame update
    void Start()
    {
        LoadSliderVolumes();
    }

    private void LoadSliderVolumes()
    {

        masterSlider.slider.value = SettingsManager.instance.GetSavedValue("masterVolume");
        bgmSlider.slider.value = SettingsManager.instance.GetSavedValue("bgmVolume");
        sfxSlider.slider.value = SettingsManager.instance.GetSavedValue("sfxVolume");
     
    
    }

    public void OnMasterVolumeSliderChanged(float v)
    {
        SettingsManager.instance.SetVolume("masterVolume",v);
        masterSlider.volumeNumber.text = GetLinearVolume("masterVolume").ToString();
   //     masterText.text = (v * 100).ToString();
    }

    public void OnBGMVolumeSliderChanged(float v)
    {
        Debug.Log(SettingsManager.instance.SetVolume("bgmVolume", v));
        bgmSlider.volumeNumber.text = GetLinearVolume("bgmVolume").ToString();
    }
    public void OnSFXVolumeSliderChanged(float v)
    {
        //this is done because the volumes are measured in decibels soo we need the maximum = 20, and the conversion Log
        SettingsManager.instance.SetVolume("sfxVolume",v); // Mathf.Log10(v)*20
        sfxSlider.volumeNumber.text = GetLinearVolume("sfxVolume").ToString();
        //   sfxText.text = (v * 100).ToString();
    }


    private int GetLinearVolume(string channel)
    {
        return Mathf.FloorToInt(SettingsManager.instance.GetLinearVolume(channel) * 100);
    }

    public void CloseSettingsPanel()
    {
        SettingsManager.instance.SaveSettings();
        //gameObject.SetActive(false);
        MenuManager.instance.DeactivateSubPanel();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CloseSettingsPanel();
        }
    }
    [System.Serializable]
    public struct SoundSliderElement
    {
        public Text volumeNumber;
        public Slider slider;
    }
}

