using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoringScript : MonoBehaviour
{
    public TextMeshProUGUI scoringLol;
    // Start is called before the first frame update
    int scoreLol=0;
    void Start()
    {
        scoringLol.text = scoreLol.ToString();
    }

    public void UpdateScore(string Lol)
    {
        if(Lol=="Lollipop")
        {
            scoreLol += 1;
            scoringLol.text = scoreLol.ToString();

            int Score = PlayerPrefs.GetInt("ScoreAkhir",0);
            int currentScore = scoreLol;
            PlayerPrefs.SetInt("ScoreAkhir",currentScore);
        }
    }

    // public void tambahtext()
    // {
    
    // }

}
