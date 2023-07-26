using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatsPanelScript : MonoBehaviour
{
    public TextMeshProUGUI pointsText;
    public TextMeshProUGUI accuracyText;
    public TextMeshProUGUI comboText;
    public TextMeshProUGUI perfectHitsText;
    public TextMeshProUGUI poorHitsText;
    public TextMeshProUGUI missesText;

    // Start is called before the first frame update
    void Start()
    {
        pointsText.text = PlayerPrefs.GetInt("score").ToString()+" Points";
        accuracyText.text = PlayerPrefs.GetFloat("accuracy").ToString()+"%";
        comboText.text = PlayerPrefs.GetInt("highestCombo").ToString();
        perfectHitsText.text = PlayerPrefs.GetInt("perfectHits").ToString();
        poorHitsText.text = PlayerPrefs.GetInt("poorHits").ToString();
        missesText.text = PlayerPrefs.GetInt("misses").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
