using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public GameObject Note; // This is the prefab for the object you want to spawn
    public float speed = 10f; // This is the speed at which the object will move



    private void Start()
    {
        Application.targetFrameRate = 60;
    }

    void SpawnObject()
    {
        

        // Instantiate the object prefab
        GameObject midNote = Instantiate(Note, transform.position, transform.rotation);
        GameObject leftNote = Instantiate(Note, transform.position=new Vector3(3.0f, 0.5f, -10.0f), transform.rotation);
        GameObject rightNote = Instantiate(Note, transform.position=new Vector3(-3.0f, 0.5f, -10.0f), transform.rotation);

        // Get the rigidbody component of the new object
        Rigidbody rbMid = midNote.GetComponent<Rigidbody>();
        Rigidbody rbLeft = leftNote.GetComponent<Rigidbody>();
        Rigidbody rbRight = rightNote.GetComponent<Rigidbody>();

        // Set the velocity of the rigidbody to make the object move in a single direction
        rbMid.velocity = transform.forward * speed;
        rbLeft.velocity = transform.forward * speed;
        rbRight.velocity = transform.forward * speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (!PauseMenu.isPaused)
        {
            if (Time.frameCount % 60 == 0)
            {
                SpawnObject();
                Debug.Log(Note.transform.position);
            }
        }
       
    }
}