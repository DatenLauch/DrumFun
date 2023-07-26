using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class ScoreScript : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI ComboText;
    public TextMeshProUGUI AccuracyText;
    private long score;
    private int combo;
    private int totalNotes;
    private int perfectHits;
    private int poorHits;
    private int misses;
    private double accuracy;
    private int highestCombo;


    void Start()
    {
    }

    void Update()
    {       
    }

    void updateScoreText()
    {
        ScoreText.text = "Score\n" + score;
    }

    void updateComboText()
    {
        ComboText.text = "Combo\n" + "x" + combo;
    }

    void updateAccuracyText()
    {
        accuracy = ((perfectHits + (double)poorHits / 2)) / totalNotes * 100f;
        accuracy = Math.Round(accuracy, 2);
        AccuracyText.text = "Accuracy\n" + accuracy + "%";
        addStatsToPlayerPrefs();
    }

    public void resetCombo()
    {
        combo = 0;
        misses++;
        totalNotes++;
        updateComboText();
        updateAccuracyText();
    }

    public void addPerfectHit(int points)
    {
        if (combo == 0)
            score = points + score;
        if (combo > 0)
            score = points * combo + score;
        perfectHits++;
        combo++;
        totalNotes++;
        updateComboText();
        updateScoreText();
        updateAccuracyText();

        if (combo > highestCombo)
        {
            highestCombo = combo;
        }
    }

    public void addPoorHit(int points)
    {
        if (combo == 0)
            score = points + score;
        if (combo > 0)
            score = points * combo + score;
        poorHits++;
        combo++;
        totalNotes++;
        updateComboText();
        updateScoreText();
        updateAccuracyText();

        if (combo > highestCombo)
        {
            highestCombo = combo;
        }
    }

    public void addStatsToPlayerPrefs()
    {
        PlayerPrefs.SetInt("score", (int)score);
        PlayerPrefs.SetFloat("accuracy", (float)accuracy);
        PlayerPrefs.SetInt("highestCombo", highestCombo);
        PlayerPrefs.SetInt("perfectHits", perfectHits);
        PlayerPrefs.SetInt("poorHits", poorHits);
        PlayerPrefs.SetInt("totalNotes", totalNotes);
        PlayerPrefs.SetInt("misses", misses);
    }
}
