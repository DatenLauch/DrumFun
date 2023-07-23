using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MidAnimationOnButtonPress : MonoBehaviour
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
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                drumAnimator.Play("hitAnimation", -1, 0f);
            }
        }
    }
}