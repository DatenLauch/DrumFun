using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class SetVolume : MonoBehaviour
{

    [SerializeField] AudioSource audioSource;
    public string audioSourceTag = "Audio";
    public Slider slider;
    public TextMeshProUGUI masterVolumePercentageText;


    void Start()
    {
        GameObject audioObject = GameObject.FindWithTag(audioSourceTag);
      
        if (audioObject != null)
        {
            audioSource = audioObject.GetComponent<AudioSource>();
            masterVolumePercentageText.text = ((int)(audioSource.volume * 100)).ToString() + "%";
            if (audioSource != null)
            {
                // Set the initial value of the Slider to match the AudioSource volume
                slider.value = audioSource.volume;

                // Subscribe to the Slider's OnValueChanged event
                slider.onValueChanged.AddListener(OnVolumeSliderValueChanged);
            }
            else
            {
                Debug.LogWarning("No AudioSource component found on the GameObject with tag: " + audioSourceTag);
            }
        }
        else
        {
            Debug.LogWarning("No GameObject found with tag: " + audioSourceTag);
        }
    }


    private void OnVolumeSliderValueChanged(float volume)
    {
        // Update the AudioSource volume based on the Slider value
        audioSource.volume = volume;
        masterVolumePercentageText.text = ((int)(volume * 100)).ToString() + "%";
    }
}
