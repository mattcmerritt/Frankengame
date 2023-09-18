using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public static event Action OnSlowdown, OnSpeedUp, OnRestoreTime;

    // time that the player still has
    [SerializeField] private CollectableDuration slowSeconds, fastSeconds;
    [SerializeField] private bool slowActive, fastActive;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) && slowSeconds.GetSeconds() > 0)
        {
            slowActive = true;
            OnSlowdown?.Invoke();
        }
        
        if (Input.GetKeyDown(KeyCode.D) && fastSeconds.GetSeconds() > 0)
        {
            fastActive = true;
            OnSpeedUp?.Invoke();
        }

        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            OnRestoreTime?.Invoke();
        }

        if (slowActive) 
        {
            slowSeconds.RemoveTime(Time.deltaTime);
            if (slowSeconds.GetSeconds() < 0)
            {
                slowActive = false;
                OnRestoreTime?.Invoke();
            }
        }
        if (fastActive)
        {
            fastSeconds.RemoveTime(Time.deltaTime);
            if (fastSeconds.GetSeconds() < 0)
            {
                fastActive = false;
                OnRestoreTime?.Invoke();
            }
        }
    }
}
