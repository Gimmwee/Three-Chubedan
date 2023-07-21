using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] GameObject gameOver;
    [SerializeField] public TextMeshProUGUI coinsText;
    public int coins = 0;
    public float initialMoveSpeed = 4f;
    public float maxMoveSpeed = 30f;
    public float acceleration = 0.2f;
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

        // Nh?y khi ch?m vào màn hình
        if (canJump && isGrounded)
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                AudioManager.Instance.PlaySFX("Jump");
                rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
                isJumping = true;
                canJump = false;
            }
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
            AudioManager.Instance.PlaySFX("Death");
            AudioManager.Instance.musicSource.Stop();
            gameOver.SetActive(true);
            Destroy(gameObject); // H?y nhân v?t
        }
    }

    public void CollectCoin()
    {
        coins++;
        coinsText.text = "Coins: " + coins;
        if (coins > PlayerPrefs.GetInt("hightScore"))
        {
            PlayerPrefs.SetInt("hightScore", coins);
        }
    }

    public void ResetCoins()
    {
        coins = 0;
        coinsText.text = "Coins: " + coins;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("coins"))
        {
            AudioManager.Instance.PlaySFX("CollectCoin");
            other.gameObject.SetActive(false);
            CollectCoin();
        }
    }

    //public void SavePlayer()
    //{
    //    SaveSystem.SavePlayer(this);
    //}

    //public void LoadPlayer()
    //{
    //    PlayerData data = SaveSystem.LoadPlayer();

    //    coins = data.score;

    //    coinsText.text = "Coins: " + coins;

    //    Vector3 position;
    //    position.x = data.position[0];
    //    position.y = data.position[1];
    //    position.z = data.position[2];
    //    transform.position = position;
    //}
}
