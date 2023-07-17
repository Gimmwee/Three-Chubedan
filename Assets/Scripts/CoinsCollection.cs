using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinsCollection : MonoBehaviour
{
    private int coins = 0;
    [SerializeField] TextMeshProUGUI coinsText;

    public void CollectCoin()
    {
        coins++;
        coinsText.text = "Coins: " + coins;
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
            AudioManager.Instance.PlaySFX("CollectCoins");
            other.gameObject.SetActive(false);
            CollectCoin();
        }
    }
}
