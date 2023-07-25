using System.Collections.Generic;
using UnityEngine;
using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Interaction;
using System;

public class SpawnerScript : MonoBehaviour
{
    MidiFile midiFile;
    [SerializeField] string midiFilePath;
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioClip musicClip;
    [SerializeField] int noteTravelTime;
    [SerializeField] float speed = 10f;
    [SerializeField] GameObject midNote;
    [SerializeField] GameObject leftNote;
    [SerializeField] GameObject rightNote;
    [SerializeField] Boolean drum1;
    [SerializeField] Boolean drum2;
    [SerializeField] Boolean drum3;
    Note[] notesArray;
    List<double> timeStamps = new List<double>();
    int spawnIndex;
    double currentAudioTime;

    void Start()
    {
        midiFile = MidiFile.Read(midiFilePath);
        ICollection<Note> notes = midiFile.GetNotes();
        notesArray = new Note[notes.Count];
        notes.CopyTo(notesArray, 0);
        setTimeStamps(notesArray);
        musicSource.clip = musicClip;
        musicSource.Play();
    }

    void Update()
    {
        if (spawnIndex < notesArray.Length)
        {
            currentAudioTime = getAudioSourceTime(musicSource);
            if (currentAudioTime != 0)
            {
                while ((currentAudioTime) >= timeStamps[spawnIndex] - noteTravelTime)
                {
                    if (notesArray[spawnIndex].ToString().Equals("C#2") && drum1)
                    {
                        spawnOjects(new Vector3(1.5f, 0.5f, -18f), leftNote);
                        //Debug.Log("D2");
                    }

                    if (notesArray[spawnIndex].ToString().Equals("C2") && drum2)
                    {
                        spawnOjects(new Vector3(0, 0.5f, -18f), midNote);
                        //Debug.Log("C2");
                    }
                    if (notesArray[spawnIndex].ToString().Equals("D2") && drum3)
                    {
                        spawnOjects(new Vector3(-1.5f, 0.5f, -18f), rightNote);
                        //Debug.Log("F#2");
                    }
                    spawnIndex++;
                    currentAudioTime = getAudioSourceTime(musicSource);
                    Debug.Log("uh oh");
                }
            }
        }
    }

    public void spawnOjects(Vector3 location, GameObject noteToSpawn)
    {

        GameObject note = Instantiate(noteToSpawn, location, transform.rotation);
        Rigidbody rbMid = note.GetComponent<Rigidbody>();
        rbMid.velocity = transform.forward * speed;
    }

    public double getAudioSourceTime(AudioSource musicSource)
    {
        return (double)musicSource.timeSamples / musicSource.clip.frequency;
    }

    void setTimeStamps(Note[] array)
    {
        foreach (var note in array)
        {
            MetricTimeSpan metricTimeSpan = TimeConverter.ConvertTo<MetricTimeSpan>(note.Time, midiFile.GetTempoMap());
            timeStamps.Add((double)metricTimeSpan.Minutes * 60f + (double)metricTimeSpan.Seconds + (double)metricTimeSpan.Milliseconds / 1000f);
        }
    }
}
