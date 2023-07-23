using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftHitscanScript : MonoBehaviour
{
    [SerializeField] ScoreScript scoreSystem;
    [SerializeField] HitsplashScript Hitsplash;
    private Collider colliderObject;
    private float startPositionPerfect = 11.85f;
    private float endPositionPerfect = 12.15f;

    void Start()
    {

    }

    void Update()
    {
        if (!PauseMenu.isPaused)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1) && colliderObject != null)
            {
                if (colliderObject.transform.position.z >= startPositionPerfect && colliderObject.transform.position.z <= endPositionPerfect)
                {
                    Debug.Log("Perfect!");
                    scoreSystem.addSuccessfulHit(300);
                    Hitsplash.activateHitsplash("PERFECT!\n+300");
                    Destroy(colliderObject.gameObject);
                    colliderObject = null;
                }

                else
                {
                    Debug.Log("Good");
                    scoreSystem.addSuccessfulHit(100);
                    Hitsplash.activateHitsplash("OKAY!\n+100");
                    Destroy(colliderObject.gameObject);
                    colliderObject = null;
                }
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
