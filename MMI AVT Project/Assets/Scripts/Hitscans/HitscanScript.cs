using UnityEngine;

public class HitscanScript : MonoBehaviour
{
    [SerializeField] ScoreScript scoreSystem;
    [SerializeField] HitsplashScript Hitsplash;
    [SerializeField] MidAnimationOnButtonPress MidAnimationOnButtonPress;
    [SerializeField] AudioSource audioSourceEffect;
    [SerializeField] float forceMagnitude; //force that gets applied
    private Collider colliderObject;
    private float startPositionPerfect = 11.75f;
    private float endPositionPerfect = 12.25f;
    private bool isHit = false; //boolean to make sure that hits dont become miss

    void Start()
    {
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2)) //checks if key 2 is pressed
        {
            activateHitscan();
        }
    }

    public void playerHitsDrum()    //checks if a drum is hit
    {
        activateHitscan();  
    }

    private void activateHitscan()
    {
        if (!PauseMenu.isPaused)
        {
            audioSourceEffect.Play();
            MidAnimationOnButtonPress.playAnimation(); //plays the drum animation

            if (colliderObject != null)
            {
                if (colliderObject.transform.position.z >= startPositionPerfect && colliderObject.transform.position.z <= endPositionPerfect)
                {
                    isHit = true;
                    scoreSystem.addPerfectHit(300);
                    Hitsplash.activateHitsplash("PERFECT!\n+300");
                    ApplyForceToColliderObject();
                    colliderObject = null;  //so the object cant be hit twice
                }

                else if (colliderObject.transform.position.z < startPositionPerfect)
                {
                    isHit = true;
                    scoreSystem.addPoorHit(100);
                    Hitsplash.activateHitsplash("Early!\n+100");
                    ApplyForceToColliderObject();
                    colliderObject = null;
                }

                else if (colliderObject.transform.position.z > endPositionPerfect)
                {
                    isHit = true;
                    scoreSystem.addPoorHit(100);
                    Hitsplash.activateHitsplash("Late!\n+100");
                    ApplyForceToColliderObject();
                    colliderObject = null;
                }
            }
        }
    }
    //method to apply force to an object, makes balls bounce
    private void ApplyForceToColliderObject()
    {
        Rigidbody colliderRb = colliderObject.GetComponent<Rigidbody>();
        if (colliderRb != null)
        {
            colliderRb.mass = 0.5f;
            colliderRb.AddForce(Vector3.up * forceMagnitude);
        }

    }
    //checks if a ball enters a hitzone
    private void OnTriggerEnter(Collider collision)
    {
        colliderObject = collision;
    }
    //if player does not hit resets the combo to zero
    private void OnTriggerExit(Collider collision)
    {
        if (!isHit)
        {
            scoreSystem.resetCombo();
            Hitsplash.activateHitsplash("Miss!\n ");
            colliderObject = null;
        }
        isHit = false;
    }
}
