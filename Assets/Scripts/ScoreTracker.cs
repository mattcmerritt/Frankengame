using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ScoreTracker : ScriptableObject
{
    public float score;

    private void OnEnable()
    {
        score = 0f;
    }

    public void AddScore()
    {
        score += 0.5f; // halved because score is double counted (player has two colliders)
    }

    public float GetScore()
    {
        return score;
    }

    public void ResetScore()
    {
        score = 0f;
    }
}
