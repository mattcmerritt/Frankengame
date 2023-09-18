using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CollectableDuration : ScriptableObject
{
    public float secondsLeft;

    private void OnEnable()
    {
        secondsLeft = 0f;
    }

    public void RemoveTime(float timeElapsed)
    {
        secondsLeft -= timeElapsed;
    }

    public void AddSecond()
    {
        secondsLeft += 1;
    }

    public float GetSeconds()
    {
        return secondsLeft;
    }
}
