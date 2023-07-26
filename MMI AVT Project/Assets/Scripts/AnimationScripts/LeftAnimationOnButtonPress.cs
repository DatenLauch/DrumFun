using UnityEngine;

public class LeftAnimationOnButtonPress : MonoBehaviour
{
    public GameObject drum;
    private Animator drumAnimator;
    private Vector3 originalPos;

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
        drum.transform.position = originalPos;
        drumAnimator.Play("hitAnimationGreen", -1, 0f);
    }
}