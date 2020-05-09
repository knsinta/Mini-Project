using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreAkhir : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI banyakLollipop;
    void Start()
    {
        banyakLollipop.text = PlayerPrefs.GetInt("ScoreAkhir",0).ToString("0");
    }
}
