using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CollectableDuration : ScriptableObject
{
    public float secondsLeft;
    public float increment = 5;

    private void OnEnable()
    {
        secondsLeft = 0f;
    }

    public void RemoveTime(float timeElapsed)
    {
        secondsLeft -= timeElapsed;
    }

    public void AddSeconds()
    {
        secondsLeft += increment;
    }

    public float GetSeconds()
    {
        return secondsLeft;
    }

    public void ResetSeconds()
    {
        secondsLeft = 0f;
    }
}
