using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float currentSpeedMultiplier = 1f;
    private Vector3 startPosition;

    // Data to make the projectiles bounce back up
    [SerializeField] private float moveSpeed, reboundDelay, currentDelay, verticalBorder;
    [SerializeField] private bool offscreen, movingUp, returnedToScreen;

    private void Start()
    {
        TimeManager.OnSlowdown += SlowDown;
        TimeManager.OnSpeedUp += SpeedUp;
        TimeManager.OnRestoreTime += RestoreSpeed;

        startPosition = transform.position;

        PlayerManager.OnReset += ResetProjectile;

        rb.velocity = Vector2.up * moveSpeed * currentSpeedMultiplier * (movingUp ? 1 : -1);
    }

    private void Update()
    {
        if (!offscreen && Mathf.Abs(transform.position.y) > verticalBorder)
        {
            offscreen = true;
            returnedToScreen = false;
        }
        
        if (offscreen && !returnedToScreen)
        {
            currentDelay += Time.deltaTime * currentSpeedMultiplier;

            // if it has been sufficiently long, have the projectile bounce back up
            if (currentDelay >= reboundDelay)
            {
                currentDelay = 0f;
                movingUp = !movingUp; // reverse directions
                rb.velocity = Vector2.up * moveSpeed * currentSpeedMultiplier * (movingUp ? 1 : -1);
            }
        }

        if (offscreen && Mathf.Abs(transform.position.y) < verticalBorder)
        {
            offscreen = false;
            returnedToScreen = true;
        }
    }

    private void ResetProjectile()
    {
        currentSpeedMultiplier = 1f;
        transform.position = startPosition;
        movingUp = false;
        rb.velocity = Vector2.up * moveSpeed * currentSpeedMultiplier * (movingUp ? 1 : -1);
    }

    private void SlowDown()
    {
        currentSpeedMultiplier = 0.5f;
        rb.velocity = rb.velocity * 0.5f;
    }

    private void SpeedUp()
    {
        currentSpeedMultiplier = 2f;
        rb.velocity = rb.velocity * 2f;
    }

    private void RestoreSpeed()
    {
        currentSpeedMultiplier = 1f;
        rb.velocity = Vector2.up * moveSpeed * currentSpeedMultiplier * (movingUp ? 1 : -1);
    }
}
