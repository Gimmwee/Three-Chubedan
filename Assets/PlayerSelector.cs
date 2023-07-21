using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerSelector : MonoBehaviour
{

    [SerializeField] private Button nextBtn, previousBtn, playBtn;

    public enum PlayerType
    {
        ThaySonUnity2D,
        PhamPhuSon,
        DangCongKien,
        NguyenPhiLong
    };

    private PlayerType currentPlayer = PlayerType.ThaySonUnity2D;

    private void Awake()
    {
        nextBtn.onClick.AddListener(() => NextPlayer());
        previousBtn.onClick.AddListener(() => PreviousPlayer());
        playBtn.onClick.AddListener(() => SelectPlayer());
    }

    void Start()
    {
        currentPlayer = (PlayerType)PlayerPrefs.GetInt("CurrentPlayer");
    }

    public void NextPlayer()
    {
        if (currentPlayer < PlayerType.NguyenPhiLong)
        {
            currentPlayer++;
        }
        else
        {
            currentPlayer = PlayerType.ThaySonUnity2D;
        }
    }

    public void PreviousPlayer()
    {
        if (currentPlayer > PlayerType.ThaySonUnity2D)
        {
            currentPlayer--;
        }
        else
        {
            currentPlayer = PlayerType.NguyenPhiLong;

        }
    }

    public void SelectPlayer()
    {
        PlayerPrefs.SetInt("CurrentPlayer", (int)currentPlayer);
        SceneManager.LoadScene(3);
    }
}
