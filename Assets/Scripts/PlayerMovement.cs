using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public float currentMoveSpeed;
    private bool canJump = true;
    public GameObject Blood;

    private Collider2D coll;

    [SerializeField] private LayerMask groundLayers;
    private void Awake()
    {
        coll = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();

        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject); // Destroy duplicate instance
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
    private void OnApplicationQuit()
    {
        // L?u th�ng tin ?i?m v� v? tr� ng??i ch?i khi tho�t game
        PlayerPrefs.SetFloat("PlayerPositionX", transform.position.x);
        PlayerPrefs.SetFloat("PlayerPositionY", transform.position.y);
        PlayerPrefs.SetInt("PlayerCoins", CoinsCollection.Instance.GetCoins());
        PlayerPrefs.Save();
    }

    public void LoadGame()
    {
        int savedCoins = PlayerPrefs.GetInt("PlayerCoins", 0); // Load the saved coins, default to 0 if not present
        float savedPlayerPosX = PlayerPrefs.GetFloat("PlayerPositionX", 0f); // Load the saved player position x, default to 0 if not present
        float savedPlayerPosY = PlayerPrefs.GetFloat("PlayerPositionY", 0f); // Load the saved player position y, default to 0 if not present

        // Set the saved coins and player position
        CoinsCollection.Instance.SetCoins(savedCoins);
        PlayerMovement.Instance.transform.position = new Vector3(savedPlayerPosX, savedPlayerPosY, 0f);

        //SceneManager.LoadScene("GameScenes", LoadSceneMode.Single);
    }

}
