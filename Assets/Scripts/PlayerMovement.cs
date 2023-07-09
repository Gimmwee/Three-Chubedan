using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] GameObject gameOver;
    [SerializeField] private AudioSource jumpSoundEffect;
    [SerializeField] private AudioSource deathSoundEffect;
    public float initialMoveSpeed = 4f;
    public float maxMoveSpeed = 10f;
    public float acceleration = 0.1f;
    public float jumpForce = 12f;
    private Rigidbody2D rb;
    private bool isJumping = false;
    private bool isGrounded = true;
    public Animator aim;
    private float currentMoveSpeed;
    private bool canJump = true;

    
    

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentMoveSpeed = initialMoveSpeed;
    }

    private void Update()
    {
        // Di chuy?n qua ph?i
        rb.velocity = new Vector2(currentMoveSpeed, rb.velocity.y);

        // Làm nhân v?t ??ng th?ng
        transform.rotation = Quaternion.Euler(0f, 0f, 0f);

        // Nh?y
        if (canJump && isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            jumpSoundEffect.Play();
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            isJumping = true;
            canJump = false;
        }

        aim.SetFloat("Move", currentMoveSpeed);
        aim.SetBool("IsJumping", isJumping);

        // T?ng t?c ?? di chuy?n
        if (currentMoveSpeed < maxMoveSpeed)
        {
            currentMoveSpeed += acceleration * Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Ki?m tra xem nhân v?t ?ã ch?m ??t hay ch?a
        if (collision.gameObject.CompareTag("Terrain"))
        {
            isJumping = false;
            isGrounded = true;
            canJump = true;
        }

        // Ki?m tra va ch?m v?i traps
        if (collision.gameObject.CompareTag("Traps"))
        {
            deathSoundEffect.Play();
            gameOver.SetActive(true);
            gameObject.SetActive(false);
           // Destroy(gameObject); // H?y nhân v?t
        }
    }
}
