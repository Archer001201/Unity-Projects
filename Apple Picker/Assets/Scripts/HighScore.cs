using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighScore : MonoBehaviour
{
    // ReSharper disable once FieldCanBeMadeReadOnly.Global
    // ReSharper disable once MemberCanBePrivate.Global
    // ReSharper disable once ConvertToConstant.Global
    public static int score = 1000;
    private TextMeshProUGUI _gt;

    private void Awake()
    {
        _gt = this.GetComponent<TextMeshProUGUI>();
        if (PlayerPrefs.HasKey("HighScore"))
        {
            score = PlayerPrefs.GetInt("HighScore");
        }
        PlayerPrefs.SetInt("HighScore", score);
    }

    private void Update()
    {
        _gt.text = "High Score: " + score;
        if (score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }
}
