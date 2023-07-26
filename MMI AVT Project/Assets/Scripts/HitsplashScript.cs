using TMPro;
using UnityEngine;

public class HitsplashScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textUI;
    [SerializeField] float duration;

    public void activateHitsplash(string textToDisplay)
    {
        textUI.CrossFadeAlpha(1, 0, false);
        textUI.text = textToDisplay;
        textUI.CrossFadeAlpha(0, duration, false);
    }
}
