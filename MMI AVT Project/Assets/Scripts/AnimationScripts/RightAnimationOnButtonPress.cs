using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightAnimationOnButtonPress : MonoBehaviour
{
    public GameObject drum;
    private Animator drumAnimator;

    private void Start()
    {
        drumAnimator = drum.GetComponent<Animator>();
    }

    void Update()
    {
        if (!PauseMenu.isPaused)
        {
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                Debug.Log("Blue!");
                drumAnimator.Play("hitAnimation", -1, 0f);
            }
        }
    }
}