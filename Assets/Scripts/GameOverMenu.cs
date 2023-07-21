using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour
{

    public static GameOverMenu Instance;

    [SerializeField] TMP_Text highscoreText;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }

        gameObject.SetActive(false);
    }
    private void Start()
    {
        ScoreDisplay();
    }
    public void ScoreDisplay()
    {
        highscoreText.text = "High Score: " + PlayerPrefs.GetInt("hightScore").ToString();
    }

    public void ShowPopup()
    {
        gameObject.SetActive(true);
    }
}
