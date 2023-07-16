using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitscanScript : MonoBehaviour
{

    [SerializeField]
    private ScoreScript scoreSystem;
    private Collider colliderObject;

    void Start()
    {

    }

    void Update()
    {
        Debug.Log("uppies!");
        if (!PauseMenu.isPaused)
        {
            if (Input.GetKeyDown(KeyCode.Alpha2) && colliderObject != null)
            {
                Debug.Log("Success!");
                Destroy(colliderObject.gameObject);
                colliderObject = null;
                scoreSystem.addSuccessfulHit(100);
            }
        }
       
    }

    private void OnTriggerEnter(Collider collision)
    {
        colliderObject = collision;
    }

    private void OnTriggerExit(Collider collision)
    {
        if (!PauseMenu.isPaused)
        {
           // Debug.Log("Missed a note!");
            colliderObject = null;
            scoreSystem.resetCombo();
        }

    }
}
