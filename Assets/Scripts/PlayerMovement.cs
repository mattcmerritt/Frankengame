using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private bool started, moving;
    [SerializeField] private float playerSpeed;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            started = false; // make player press and release space again
            moving = false; // player will not be automatically moving
            transform.position = startPosition; // reset to starting position
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            // start game on first space
            if (!started)
            {
                started = true;
                moving = true;
            }
            // otherwise change between moving and not moving
            else 
            {
                moving = !moving;
            }
        }
    }

    private void FixedUpdate()
    {
        if (moving)
        {
            rb.velocity = Vector2.right * playerSpeed + Vector2.up * rb.velocity.y; // go forward and preserve vertical speed
        }
        else {
            rb.velocity = Vector2.up * rb.velocity.y; // only keep vertical speed
        }
    }
}
