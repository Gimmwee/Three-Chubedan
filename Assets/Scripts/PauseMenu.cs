using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    private int coins = 0;
    private Vector3 initialPlayerPosition;

    public TextMeshProUGUI coinsText; // S?a t? private thành public
    SavePlayerPos playerPosData;

    public void Start()
    {
        playerPosData = FindObjectOfType<SavePlayerPos>();
        initialPlayerPosition = transform.position;
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Quit()
    {
        playerPosData.PlayerPosSave();
        SceneManager.LoadScene("Start Screen");

    }

    public void ReGame()
    {
        // ??t l?i v? trí c?a nhân v?t v? v? trí ban ??u
        transform.position = initialPlayerPosition;

        // ??t l?i ?i?m s?
        coins = 0;
        UpdateCoinsText();

        // T?i l?i c?nh hi?n t?i ?? ch?i l?i t? ??u
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void CollectCoin()
    {
        coins++;
        UpdateCoinsText();
    }

    private void UpdateCoinsText()
    {
        coinsText.text = "Coins: " + coins;
    }
}
