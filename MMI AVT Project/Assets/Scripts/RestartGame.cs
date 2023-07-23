using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class RestartGame : MonoBehaviour
{
    public TextMeshProUGUI pointsText;
    // Start is called before the first frame update
    void Start()
    {
        int score = PlayerPrefs.GetInt("Score");
        Debug.Log(score);
        // Display the score value in a Text component
        pointsText.text = "Score: " + score;

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
