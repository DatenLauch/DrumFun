using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MusicScript : MonoBehaviour
{
    [SerializeField] AudioClip audioClip;
    AudioSource musicSource;

    void Start()
    {
        musicSource = this.GetComponent<AudioSource>();
        musicSource.clip = audioClip;
    }

    void Update()
    {
        
    }

    public void playMusic()
    {
        musicSource.Play();
    }
}
