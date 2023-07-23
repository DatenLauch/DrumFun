using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Interaction;
using UnityEngine.Assertions.Must;

public class SpawnerScript : MonoBehaviour
{
    MidiFile midiFile;
    [SerializeField] string midiFilePath;
    [SerializeField] AudioSource musicSource;
    [SerializeField] int noteTravelTime;

    List<double> timeStamps = new List<double>();
    int spawnIndex;
    double currentAudioTime;

    
    [SerializeField] float speed = 10f;

    public GameObject midNote;
    public GameObject leftNote;
    public GameObject rightNote;

   // GameObject MidSpawner;

    Note[] notesArray;

    void Start()
    {
        //get midi data
        midiFile = MidiFile.Read(midiFilePath);
        ICollection<Note> notes = midiFile.GetNotes();
        notesArray = new Note[notes.Count];
        notes.CopyTo(notesArray, 0);
        setTimeStamps(notesArray);

        Invoke(nameof(startMusicPlayer), noteTravelTime);
    }

    void Update()
    {
        if (spawnIndex < notesArray.Length)
        {
            currentAudioTime = getAudioSourceTime(musicSource);
            if (currentAudioTime != 0)
            {
                if ((currentAudioTime) >= timeStamps[spawnIndex])
                {
                    if (notesArray[spawnIndex].ToString().Equals("D2"))
                    {
                        //leftSpawner.SpawnObject();
                        spawnOjects(new Vector3(1.5f, 0.5f, -18f), leftNote);
                        Debug.Log("D2");
                    }

                    if (notesArray[spawnIndex].ToString().Equals("C2"))
                    {
                        spawnOjects(new Vector3(0, 0.5f, -18f), midNote);
                        //midSpawner.SpawnObject();
                        Debug.Log("C2");
                    }
                    if (notesArray[spawnIndex].ToString().Equals("F#2"))
                    {
                        spawnOjects(new Vector3(-1.5f, 0.5f, -18f), rightNote);
                        //rightSpawner.SpawnObject();
                        Debug.Log("F#2");
                    }
                    spawnIndex++;
                    Debug.Log(notesArray[spawnIndex - 1]);
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

    void startMusicPlayer()
    {
        musicSource.GetComponent<MusicScript>().playMusic();
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
