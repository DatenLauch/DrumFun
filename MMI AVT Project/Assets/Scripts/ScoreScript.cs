using UnityEngine;
using TMPro;
using System;

public class ScoreScript : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI ComboText;
    public TextMeshProUGUI AccuracyText;
    private long score;
    private int combo;
    private int totalNotes;
    private int misses;
    private int hits;
    private double accuracy;

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
        if (misses == 0)
        {
            accuracy = 100;
            AccuracyText.text = "Accuracy\n" + accuracy + "%";
        }

        else if (hits == 0)
        {
            accuracy = 0;
            AccuracyText.text = "Accuracy\n" + accuracy + "%";
        }
        else
        {
            accuracy = ((double)hits / totalNotes) * 100;
            accuracy = Math.Round(accuracy, 2);
            AccuracyText.text = "Accuracy\n" + accuracy + "%";
        }
    }

    public void resetCombo()
    {
        combo = 0;
        misses++;
        totalNotes++;
        updateComboText();
        updateAccuracyText();
    }

    public void addSuccessfulHit(int points)
    {
        if (combo == 0)
            score = points + score;
        if (combo > 0)
            score = points * combo + score;
        hits++;
        combo++;
        totalNotes++;
        updateComboText();
        updateScoreText();
        updateAccuracyText();
    }
}
