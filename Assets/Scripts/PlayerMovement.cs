using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float MoveSpeed, JumpForce;
    [SerializeField] private bool Grounded;

    private void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)) && Grounded)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, JumpForce);
        }
        GetComponent<Rigidbody2D>().velocity = new Vector2(horizontalInput * MoveSpeed, GetComponent<Rigidbody2D>().velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Grounded = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Grounded = false;
    }
}
