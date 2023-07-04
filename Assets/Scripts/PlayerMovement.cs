using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 4f;
    public float jumpForce = 6f; // ?? cao c?a nh?y
    private Rigidbody2D rb;
    private bool isJumping = false;
    public Animator aim;

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
        // Ki?m tra xem nhân v?t ?ã ch?m ??t hay ch?a
        if (collision.gameObject.name == "Terrain")
        {
            isJumping = true;
        }

        // Ki?m tra xem nhân v?t ?ã ch?m vào hình tròn ho?c b?y hay ch?a
        if (collision.gameObject.tag == ("Traps"))
        {
            Destroy(gameObject); // Phá h?y nhân v?t
            // Thêm các x? lý ho?c thông báo phá h?y nhân v?t ? ?ây
        }
    }
}
