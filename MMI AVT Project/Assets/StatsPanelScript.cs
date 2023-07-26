using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatsPanelScript : MonoBehaviour
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
        pointsText.text = PlayerPrefs.GetInt("score").ToString()+" Points";
        accuracyText.text = PlayerPrefs.GetFloat("accuracy").ToString()+"%";
        comboText.text = PlayerPrefs.GetInt("highestCombo").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
