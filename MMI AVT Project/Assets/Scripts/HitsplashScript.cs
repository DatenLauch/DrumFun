using System.Collections;
using TMPro;
using UnityEngine;

public class HitsplashScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    public void activateHitsplash(string textToDisplay)
    {
        StopCoroutine(coroutineHitsplash(textToDisplay));
        StartCoroutine(coroutineHitsplash(textToDisplay));    
    }

    void showText()
    {
        Debug.Log("show");
        text.enabled = true;
    }

    void hideText()
    {
        Debug.Log("hide");
        text.enabled = false;
    }

    IEnumerator coroutineHitsplash(string textToDisplay)
    {
        text.text = textToDisplay;
        yield return new WaitForSeconds(5f);
        text.text = "";
    }


    // Update is called once per frame
    void Update()
    {

    }
}
