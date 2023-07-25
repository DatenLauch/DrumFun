using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class RestartGame : MonoBehaviour
{
    public TextMeshProUGUI pointsText;
    public TextMeshProUGUI accuracyText;
    public TextMeshProUGUI comboText;
    public TextMeshProUGUI perfectHitText;
    public TextMeshProUGUI goodHitText;
    public TextMeshProUGUI okHitText;
    // Start is called before the first frame update
    void Start()
    {
        int score = PlayerPrefs.GetInt("Score");
        // Display the score value in a Text component
        pointsText.text = score.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("DrumFunMain");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
