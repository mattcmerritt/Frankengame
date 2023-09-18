using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static event Action OnReset;

    [SerializeField] private CollectableDuration slowDown, speedUp;
    [SerializeField] private ScoreTracker score;

    private void Start()
    {
        OnReset += ResetCollectedSeconds;
        OnReset += ResetScore;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetGame();
        }
    }

    public static void ResetGame()
    {
        OnReset?.Invoke();
    }

    private void ResetCollectedSeconds()
    {
        slowDown.ResetSeconds();
        speedUp.ResetSeconds();
    }

    private void ResetScore()
    {
        score.ResetScore();
    }
}
