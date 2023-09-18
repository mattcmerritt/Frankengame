using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public static event Action OnSlowdown, OnSpeedUp, OnRestoreTime;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            OnSlowdown?.Invoke();
        }
        
        if (Input.GetKeyDown(KeyCode.D))
        {
            OnSpeedUp?.Invoke();
        }

        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            OnRestoreTime?.Invoke();
        }
    }
}
