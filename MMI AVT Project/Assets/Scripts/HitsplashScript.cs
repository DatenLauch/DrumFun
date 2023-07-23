using System.Collections;
using TMPro;
using UnityEngine;

public class HitsplashScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textUI;
    [SerializeField] float duration;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void activateHitsplash(string textToDisplay)
    {
        textUI.text = "";
        StopCoroutine(coroutineHitsplash(textToDisplay));
        StartCoroutine(coroutineHitsplash(textToDisplay));
    }

    IEnumerator coroutineHitsplash(string textToDisplay)
    {
        textUI.text = textToDisplay;
        //text.CrossFadeAlpha(1f, 0f, false);
        //text.CrossFadeAlpha(0f, duration, false);
        yield return new WaitForSeconds(duration);
        textUI.text = "";
    }


    // Update is called once per frame
    void Update()
    {

    }
}
