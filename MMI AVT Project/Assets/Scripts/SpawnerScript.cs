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
        GameObject newObject = Instantiate(Note, transform.position, transform.rotation);

        // Get the rigidbody component of the new object
        Rigidbody rb = newObject.GetComponent<Rigidbody>();

        // Set the velocity of the rigidbody to make the object move in a single direction
        rb.velocity = transform.forward * speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.frameCount % 60 == 0)
        {
            SpawnObject();
        }
    }
}