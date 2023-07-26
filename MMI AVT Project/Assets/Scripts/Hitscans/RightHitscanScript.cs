using UnityEngine;

public class RightHitscanScript : MonoBehaviour
{
    [SerializeField] ScoreScript scoreSystem;
    [SerializeField] HitsplashScript Hitsplash;
    [SerializeField] AudioSource audioSourceEffect;
    private Collider colliderObject;
    private float startPositionPerfect = 11.75f;
    private float endPositionPerfect = 12.25f;

    void Start()
    {
    }

    void Update()
    {
        if (!PauseMenu.isPaused)
        {
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                audioSourceEffect.Play();

                if (colliderObject != null)
                {
                    {
                        if (colliderObject.transform.position.z >= startPositionPerfect && colliderObject.transform.position.z <= endPositionPerfect)
                        {
                            Debug.Log("Perfect!");
                            scoreSystem.addSuccessfulHit(300);
                            Hitsplash.activateHitsplash("PERFECT!\n+300");
                            Destroy(colliderObject.gameObject);
                            colliderObject = null;
                        }

                        else if (colliderObject.transform.position.z < startPositionPerfect)
                        {
                            Debug.Log("Good");
                            scoreSystem.addSuccessfulHit(100);
                            Hitsplash.activateHitsplash("Early!\n+100");
                            Destroy(colliderObject.gameObject);
                            colliderObject = null;
                        }
                        else if (colliderObject.transform.position.z > endPositionPerfect)
                        {
                            Debug.Log("Good");
                            scoreSystem.addSuccessfulHit(100);
                            Hitsplash.activateHitsplash("Late!\n+100");
                            Destroy(colliderObject.gameObject);
                            colliderObject = null;
                        }
                    }
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
        scoreSystem.resetCombo();
        Hitsplash.activateHitsplash("Miss!\n ");
        colliderObject = null;
    }
}
