using UnityEngine;

public class RightAnimationOnButtonPress : MonoBehaviour
{
    public GameObject drum;
    private Animator drumAnimator;  //Animator Object
    private Vector3 originalPos;    //original position 

    private void Start()
    {
        drumAnimator = drum.GetComponent<Animator>();
        originalPos = drum.transform.position;
    }

    void Update()
    {
    }

    public void playAnimation()
    {   
        drum.transform.position = originalPos;        //sets the original position so the drum does not move move if the player starts the animation anew mid animation
        drumAnimator.Play("hitAnimationGreen", -1, 0f);    //plays the animation stored in the animator controller
    }
}