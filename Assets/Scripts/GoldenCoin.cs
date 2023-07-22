using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldenCoin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            CoinsCollection.Instance.CollectCoin();
            gameObject.SetActive(false);
        }
    }


}
