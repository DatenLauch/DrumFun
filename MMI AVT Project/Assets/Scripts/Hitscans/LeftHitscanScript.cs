using UnityEngine;

public class LeftHitscanScript : MonoBehaviour
{
    [SerializeField] ScoreScript scoreSystem;
    [SerializeField] HitsplashScript Hitsplash;
    [SerializeField] AudioSource audioSourceEffect;
    [SerializeField] float forceMagnitude = 50f;
    private Collider colliderObject;
    private float startPositionPerfect = 11.75f;
    private float endPositionPerfect = 12.25f;
    private bool isHit = false;

    void Start()
    {
    }

    void Update()
    {
        if (!PauseMenu.isPaused)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                audioSourceEffect.Play();

                if (colliderObject != null)
                {
                    {
                        if (colliderObject.transform.position.z >= startPositionPerfect && colliderObject.transform.position.z <= endPositionPerfect)
                        {
                            Debug.Log("Perfect!");
                            isHit = true;
                            scoreSystem.addSuccessfulHit(300);
                            Hitsplash.activateHitsplash("PERFECT!\n+300");
                            ApplyForceToColliderObject();
                            //Destroy(colliderObject.gameObject);
                            colliderObject = null;

                        }

                        else if (colliderObject.transform.position.z < startPositionPerfect)
                        {
                            isHit = true;
                            Debug.Log("Good");
                            scoreSystem.addSuccessfulHit(100);
                            Hitsplash.activateHitsplash("Early!\n+100");
                            ApplyForceToColliderObject();
                            //Destroy(colliderObject.gameObject);
                            colliderObject = null;

                        }
                        else if (colliderObject.transform.position.z > endPositionPerfect)
                        {
                            isHit = true;
                            Debug.Log("Good");
                            scoreSystem.addSuccessfulHit(100);
                            Hitsplash.activateHitsplash("Late!\n+100");
                            ApplyForceToColliderObject();
                            //Destroy(colliderObject.gameObject);
                            colliderObject = null;
                        }

                    }
                }
            }
        }
    }

    private void ApplyForceToColliderObject()
    {
        Rigidbody colliderRb = colliderObject.GetComponent<Rigidbody>();
        if (colliderRb != null)
        {
            //colliderRb.mass = 0.5f;
            colliderRb.AddForce(Vector3.up * forceMagnitude + Vector3.right * forceMagnitude);
        }

    }

    private void OnTriggerEnter(Collider collision)
    {
        colliderObject = collision;
    }

    private void OnTriggerExit(Collider collision)
    {
        if (!isHit)
        {
            Debug.Log("real Miss");
            scoreSystem.resetCombo();
            Hitsplash.activateHitsplash("Miss!\n ");
            colliderObject = null;
        }
        isHit = false;
    }
}
