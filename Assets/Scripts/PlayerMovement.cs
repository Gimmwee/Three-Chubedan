using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //public float moveSpeed = 4f;
    //public float jumpForce = 12f;
    //private Rigidbody2D rb;
    //private bool isJumping = false;
    //public Animator aim;

    //private void Start()
    //{
    //    rb = GetComponent<Rigidbody2D>();
    //}

    //private void Update()
    //{
    //    rb.velocity = new Vector2(moveSpeed, rb.velocity.y);

    //    transform.rotation = Quaternion.Euler(0f, 0f, 0f);

    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
    //        isJumping = false;

    //    }
    //    aim.SetFloat("Move", moveSpeed);
    //    aim.SetBool("IsJump", isJumping);
    //}
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.name == "Terrain")
    //    {
    //        isJumping = true;
    //    }

    //    if (collision.gameObject.tag == ("Traps"))
    //    {
    //        Destroy(gameObject);
    //    }
    //}

    public float moveSpeed = 4f;
    public float jumpForce = 12f;
    private Rigidbody2D rb;
    private bool isJumping = false;

    private enum MovementSate { idle, running, jumping, falling }
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Di chuy?n qua ph?i
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);

        // L�m nh�n v?t ??ng th?ng
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
        // Ki?m tra xem nh�n v?t ?� ch?m ??t hay ch?a
        if (collision.gameObject.name == "Terrain")
        {
            isJumping = false;
        }

        // Ki?m tra va ch?m v?i traps
        if (collision.gameObject.CompareTag("Traps"))
        {
            Destroy(gameObject); // Destroy nh�n v?t
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Ki?m tra va ch?m v?i coins
        if (other.gameObject.CompareTag("coins"))
        {
            Destroy(other.gameObject); // Destroy coins
        }
    }
}
