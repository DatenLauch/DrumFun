using UnityEngine;

public class LeftSpawnerScript : MonoBehaviour
{
    public GameObject LeftNote; 
    public float speed = 10f; 

    private void Start()
    {
        Application.targetFrameRate = 60;
    }

    public void SpawnObject()
    {
        GameObject midNote = Instantiate(LeftNote, transform.position, transform.rotation);
        Rigidbody rbMid = midNote.GetComponent<Rigidbody>();
        rbMid.velocity = transform.forward * speed;

       // Note.transform.position = new Vector3(0f, 0.5f, -10f);
    }

    // Update is called once per frame
    void Update()
    {
        if (!PauseMenu.isPaused)
        {
            if (Time.frameCount % 60 == 0)
            {
               // SpawnObject();
               // Debug.Log(midNote.transform.position);
            }
        }
       
    }
}