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
    private GameObject[] audioObjects;

    void Start()
    {
        // Find all GameObjects with the specified tag
        audioObjects = GameObject.FindGameObjectsWithTag(audioSourceTag);

        masterVolumePercentageText.text = "100%";

        if(audioObjects.Length == 0 || audioObjects == null)
        {
            Debug.Log("No game objects with tag :" + audioSourceTag + " found");
        }
        else
        {
            // Loop through each GameObject and change the volume of the AudioSource
            foreach (GameObject audioObject in audioObjects)
            {
                AudioSource audioSource = audioObject.GetComponent<AudioSource>();

                // Subscribe to the Slider's OnValueChanged event
                slider.onValueChanged.AddListener(OnVolumeSliderValueChanged);
            }
            slider.value = 100;
        }
     
        


    }


    private void OnVolumeSliderValueChanged(float volume)
    {
        if (audioObjects.Length == 0 || audioObjects == null)
        {
            Debug.Log("No game objects with tag :" + audioSourceTag + " found");
        }
        else
        {
            // Loop through each GameObject and change the volume of the AudioSource
            foreach (GameObject audioObject in audioObjects)
            {
                AudioSource audioSource = audioObject.GetComponent<AudioSource>();

                // Update the AudioSource volume based on the Slider value
                audioSource.volume = volume;

            }

            masterVolumePercentageText.text = ((int)(volume * 100)).ToString() + "%";
        }
     
    }
}
