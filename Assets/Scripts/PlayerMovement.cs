using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 4f;
    public float jumpForce = 6f; // ?? cao c?a nh?y
    private Rigidbody2D rb;
    private bool isJumping = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Di chuy?n qua ph?i
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);

        // Làm nhân v?t ??ng th?ng
        transform.rotation = Quaternion.Euler(0f, 0f, 0f);

        // Nh?y
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            isJumping = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Ki?m tra xem nhân v?t ?ã ch?m ??t hay ch?a
        if (collision.gameObject.name == "Terrain")
        {
            isJumping = false;
        }
    }
}
