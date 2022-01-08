using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsUIController : MonoBehaviour
{
   /* public Slider masterSlider;
    public Slider bgmSlider;
    public Slider sfxSlider;

    public Text masterText;
    public Text bgmText;
    public Text sfxText;*/

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
        masterSlider.volumeNumber.text = Mathf.FloorToInt((SettingsManager.instance.GetLinearVolume("masterVolume")*100)).ToString();
   //     masterText.text = (v * 100).ToString();
    }

    public void OnBGMVolumeSliderChanged(float v)
    {
        Debug.Log(SettingsManager.instance.SetVolume("bgmVolume", v));
        bgmSlider.volumeNumber.text = Mathf.FloorToInt(SettingsManager.instance.GetLinearVolume("bgmVolume")*100).ToString();
    }
    public void OnSFXVolumeSliderChanged(float v)
    {
        //this is done because the volumes are measured in decibels soo we need the maximum = 20, and the conversion Log
        SettingsManager.instance.SetVolume("sfxVolume",v); // Mathf.Log10(v)*20
        sfxSlider.volumeNumber.text = Mathf.FloorToInt(SettingsManager.instance.GetLinearVolume("sfxVolume")*100).ToString();
        //   sfxText.text = (v * 100).ToString();
    }

    public void CloseSettingsPanel()
    {
        SettingsManager.instance.SaveSettings();
        gameObject.SetActive(false);
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

