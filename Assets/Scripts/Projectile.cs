using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float currentSpeed = 1f;
    [SerializeField] private Vector3 startPosition;

    private void Start()
    {
        TimeManager.OnSlowdown += SlowDown;
        TimeManager.OnSpeedUp += SpeedUp;
        TimeManager.OnRestoreTime += RestoreSpeed;

        startPosition = transform.position;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            transform.position = startPosition;
            rb.velocity = Vector2.zero;
            currentSpeed = 1f;
            rb.gravityScale = 1f;
        }
    }

    private void SlowDown()
    {
        currentSpeed = 0.5f;
        rb.gravityScale = 0.5f;
        rb.velocity = rb.velocity * 0.5f;
    }

    private void SpeedUp()
    {
        currentSpeed = 2f;
        rb.gravityScale = 2f;
        rb.velocity = rb.velocity * 2f;
    }

    private void RestoreSpeed()
    {
        // restore proper speed based on if it was sped up or slowed down
        if (currentSpeed == 2f)
        {
            rb.velocity = rb.velocity / 2f;
        }
        else if (currentSpeed == 0.5f)
        {
            rb.velocity = rb.velocity * 2f;
        }
        currentSpeed = 1f;
        rb.gravityScale = 1f;
    }
}
