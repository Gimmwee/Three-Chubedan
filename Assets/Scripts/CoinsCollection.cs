using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinsCollection : MonoBehaviour
{
    private int coins = 0;

    [SerializeField]
    TextMeshProUGUI coinsText;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Ki?m tra va ch?m v?i coins
        if (other.gameObject.CompareTag("coins"))
        {
            other.gameObject.SetActive(false);
            coins++;
            coinsText.text = "Coins: " + coins;
        }
    }


}
