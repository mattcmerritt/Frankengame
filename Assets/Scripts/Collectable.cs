using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    private void Start()
    {
        PlayerManager.OnReset += Reset;
    }

    private void Reset()
    {
        gameObject.SetActive(true);
    }
}
