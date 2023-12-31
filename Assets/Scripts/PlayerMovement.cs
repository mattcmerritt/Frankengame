using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private bool started, moving, grounded;
    [SerializeField] private float playerSpeed, jumpForce;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Vector3 startPosition;
    [SerializeField] private CollectableDuration slowDown, speedUp;
    [SerializeField] private ScoreTracker score; 

    private void Start()
    {
        startPosition = transform.position;
        PlayerManager.OnReset += ResetPlayer; 
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            started = true;
            moving = !moving;
        }

        if (grounded && Input.GetKeyDown(KeyCode.W))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            grounded = false;
        }
    }

    private void FixedUpdate()
    {
        if (moving)
        {
            rb.velocity = Vector2.right * playerSpeed + Vector2.up * rb.velocity.y; // go forward and preserve vertical speed
        }
        else 
        {
            rb.velocity = Vector2.up * rb.velocity.y; // only keep vertical speed
        }
    }

    private void ResetPlayer()
    {
        started = false;
        moving = false; // player will not be automatically moving
        transform.position = startPosition; // reset to starting position
        rb.velocity = Vector2.zero;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Terrain"))
        {
            grounded = true;
        }
        else if (collision.gameObject.CompareTag("Speed Up"))
        {
            speedUp.AddSeconds();
            collision.gameObject.SetActive(false);
        }
        else if (collision.gameObject.CompareTag("Slow Down"))
        {
            slowDown.AddSeconds();
            collision.gameObject.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Terrain"))
        {
            grounded = false;
        }
        if (collision.gameObject.CompareTag("Checkpoint") && started)
        {
            score.AddScore();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.collider.gameObject.CompareTag("Terrain"))
        {
            PlayerManager.ResetGame();
        }
    }
}
