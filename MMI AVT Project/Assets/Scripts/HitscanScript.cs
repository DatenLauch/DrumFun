using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitscanScript : MonoBehaviour
{
    public GameObject note;
    public bool checkHitBox = false;
    public Collider colliderObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (checkHitBox && Input.GetKeyDown(KeyCode.Space))
        {
            if(colliderObject != null)
            {
                Collider prefab;
                Debug.Log("Success");
                Destroy(colliderObject.gameObject);
                colliderObject = null;
            }
            
        }

    }

    private void testPress()
    {
        

    }

    private void OnTriggerEnter(Collider collision)
    {
        colliderObject = collision;
        if (colliderObject.CompareTag("NoteMid"))
        {
            checkHitBox = true;
        }
        
        /*if(collision.gameObject.CompareTag("NoteMid"))
        {
            Debug.Log("Collision!!!!");
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("success!!");
                Destroy(collision.gameObject);
            }
            else Debug.Log("you Sucks!");
        }*/

    }

    private void OnTriggerExit(Collider other)
    {
        colliderObject = other;
        if (colliderObject.CompareTag("NoteMid"))
        {
            checkHitBox = false;
        }
    }
}
