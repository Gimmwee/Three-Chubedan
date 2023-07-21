using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinsCollection : MonoBehaviour
{
    public static CoinsCollection Instance;



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
    }
    private int coins = 0;
    [SerializeField] TextMeshProUGUI coinsText;

    public void CollectCoin()
    {
        AudioManager.Instance.PlaySFX("CollectCoin");
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

  

}
