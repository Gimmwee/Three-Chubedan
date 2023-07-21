using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public static PlayerMovement Instance;


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

    private Collider2D coll;

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

        // Làm nhân v?t ??ng th?ng
        transform.rotation = Quaternion.Euler(0f, 0f, 0f);

        

        // Nh?y khi ch?m vào màn hình
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
        // Ki?m tra xem nhân v?t ?ã ch?m ??t hay ch?a
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
            Destroy(gameObject); // H?y nhân v?t
        }
    }
}
