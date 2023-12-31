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

    public TextMeshProUGUI coinsText; // S?a t? private th�nh public

    private void Start()
    {
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

    public void GoToCharacterSelectorScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(2);
    }

    public void Quit()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    public void ReGame()
    {
        AudioManager.Instance.musicSource.Play();
        // ??t l?i v? tr� c?a nh�n v?t v? v? tr� ban ??u
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
