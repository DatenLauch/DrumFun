using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Rendering;

public class SoundManager : MonoBehaviour
{
    public Slider masterVolumeSlider;
    public TextMeshProUGUI masterVolumePercentageText;
    void Start()
    {
        if (!PlayerPrefs.HasKey("masterVolume"))
        {
            masterVolumePercentageText.text = "100%";
            masterVolumeSlider.value = 1f;
            PlayerPrefs.SetFloat("masterVolume", 1f);
          
            Load();
        }
        else
        {
            Load();
        }

    }

    public void changeMasterVolume()
    {
        AudioListener.volume = masterVolumeSlider.value;
        masterVolumePercentageText.text = ((int)(masterVolumeSlider.value * 100)).ToString() + "%";
        Save();
    }

    private void Load()
    {
        masterVolumePercentageText.text = ((int)(PlayerPrefs.GetFloat("masterVolume") * 100)).ToString() + "%";
        masterVolumeSlider.value = PlayerPrefs.GetFloat("masterVolume");
        masterVolumeSlider.value = PlayerPrefs.GetFloat("masterVolume");
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("masterVolume", masterVolumeSlider.value);
    }
}
