using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    [SerializeField] private CollectableDuration slowSeconds, fastSeconds;
    [SerializeField] private ScoreTracker score;
    [SerializeField] private TMP_Text slowText, fastText, scoreText;

    private void Update()
    {
        slowText.text = $"Slow Down: \n{slowSeconds.GetSeconds().ToString("0.##")}s";
        fastText.text = $"Speed Up: \n{fastSeconds.GetSeconds().ToString("0.##")}s";
        scoreText.text = $"Score: \n{Mathf.FloorToInt(score.GetScore())}";
    }
}
