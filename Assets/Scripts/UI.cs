using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    [SerializeField] private CollectableDuration slowSeconds, fastSeconds;
    [SerializeField] private TMP_Text slowText, fastText;

    private void Update()
    {
        slowText.text = $"Slow Down: {slowSeconds.GetSeconds().ToString("0.##")}s";
        fastText.text = $"Speed Up: {fastSeconds.GetSeconds().ToString("0.##")}s";
    }
}
