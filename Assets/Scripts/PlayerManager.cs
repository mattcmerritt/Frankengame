using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static event Action OnReset;

    [SerializeField] private CollectableDuration slowDown, speedUp;

    private void Start()
    {
        OnReset += ResetCollectedSeconds;
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
}
