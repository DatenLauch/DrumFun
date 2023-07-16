using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SoundManager : MonoBehaviour
{
    [SerializeField] Slider masterVolumeSlider;
    public TextMeshProUGUI masterVolumePercentageText;
    void Start()
    {
        if (!PlayerPrefs.HasKey("masterVolume"))
        {
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
        masterVolumePercentageText.text = (masterVolumeSlider.value).ToString() + "%";
        Save();
    }

    private void Load()
    {
        masterVolumeSlider.value = PlayerPrefs.GetFloat("masterVolume");
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("masterVolume", masterVolumeSlider.value);
    }
}
