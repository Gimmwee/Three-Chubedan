using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement Instance;

    public float initialMoveSpeed = 4f;
    public float maxMoveSpeed = 30f;
    public float acceleration = 0.2f;
    public float jumpForce = 12f;
    public float currentMoveSpeed;

    private bool isJumping = false;
    private bool isGrounded = true;
    private bool canJump = true;

    public int coins = 0;

    public Animator aim;
    private Rigidbody2D rb;
    public GameObject Blood;
    private Collider2D coll;

    [SerializeField] public TextMeshProUGUI coinsText;
    [SerializeField] private LayerMask groundLayers;
    private void Awake()
    {
        coll = GetComponent<Collider2D>();
        if (Instance == null)
        {
            Instance = this;
        } else
        {
            Destroy(this);
        }
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentMoveSpeed = initialMoveSpeed;
    }

    public enum PlayerState
    {
        Run = 0,
        Jump = 1,
    }

    private PlayerState currentState = PlayerState.Run;

    private void Update()
    {
        // Di chuy?n qua ph?i
        rb.velocity = new Vector2(currentMoveSpeed, rb.velocity.y);

        // L�m nh�n v?t ??ng th?ng
        transform.rotation = Quaternion.Euler(0f, 0f, 0f);

        // Nh?y khi ch?m v�o m�n h�nh
        if (canJump && IsOnGround())
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                Debug.Log(currentState.ToString());
                AudioManager.Instance.PlaySFX("Jump");
                rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
                isJumping = true;
                currentState = PlayerState.Jump;
                canJump = false;
            }
        }

        aim.SetInteger("Move", (int) currentState);

        // T?ng t?c ?? di chuy?n
        if (currentMoveSpeed < maxMoveSpeed)
        {
            currentMoveSpeed += acceleration * Time.deltaTime;
        }
    }
    public bool IsOnGround()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, 1f, groundLayers);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Ki?m tra xem nh�n v?t ?� ch?m ??t hay ch?a
        if (collision.gameObject.CompareTag("Terrain"))
        {
            currentState = PlayerState.Run;
     
            isJumping = false;
            isGrounded = true;
            canJump = true;
        }

        // Ki?m tra va ch?m v?i traps
        if (collision.gameObject.CompareTag("Traps"))
        {
            AudioManager.Instance.PlaySFX("Death");
            AudioManager.Instance.musicSource.Stop();
            GameOverMenu.Instance.ShowPopup();
            Destroy(gameObject); // H?y nh�n v?t
            Instantiate(Blood, transform.position, Quaternion.identity);
        }
    }
    public void ApplySlowDown(float slowDownFactor)
    {
        // �p d?ng hi?u ?ng l�m ch?m t?c ??
        initialMoveSpeed *= slowDownFactor;
    }

    public void ResetSpeed()
    {
        // H?i ph?c t?c ?? ban ??u
        currentMoveSpeed = initialMoveSpeed;
    }

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        coins = data.score;

        coinsText.text = "Coins: " + coins;

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;
    }
}
