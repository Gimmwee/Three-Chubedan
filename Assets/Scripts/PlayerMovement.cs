using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 4f;
    public float jumpForce = 12f;
    private Rigidbody2D rb;
    private bool isJumping = false;
    public Animator aim;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);

        transform.rotation = Quaternion.Euler(0f, 0f, 0f);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            isJumping = false;

        }
        aim.SetFloat("Move", moveSpeed);
        aim.SetBool("IsJump", isJumping);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Terrain")
        {
            isJumping = true;
        }

        if (collision.gameObject.tag == ("Traps"))
        {
            Destroy(gameObject);
        }
    }


}
