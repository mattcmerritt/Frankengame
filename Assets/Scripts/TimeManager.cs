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

        if (slowActive) 
        {
            if (Input.GetKeyUp(KeyCode.A))
            {
                slowActive = false;
                OnRestoreTime?.Invoke();
            }

            slowSeconds.RemoveTime(Time.deltaTime);
            if (slowSeconds.GetSeconds() < 0)
            {
                slowActive = false;
                OnRestoreTime?.Invoke();
            }
        }
        if (fastActive)
        {
            if (Input.GetKeyUp(KeyCode.D))
            {
                fastActive = false;
                OnRestoreTime?.Invoke();
            }

            fastSeconds.RemoveTime(Time.deltaTime);
            if (fastSeconds.GetSeconds() < 0)
            {
                fastActive = false;
                OnRestoreTime?.Invoke();
            }
        }
    }
}
