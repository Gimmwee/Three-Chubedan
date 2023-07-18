using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField] TMP_Text highscoreText;
    private void Start()
    {
        ScoreDisplay();
    }
    public void ScoreDisplay()
    {
        highscoreText.text = "High Score: " + PlayerPrefs.GetInt("hightScore").ToString();
    }
}
