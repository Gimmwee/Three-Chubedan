using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlayerSelector;

public class PlayerGenerator : MonoBehaviour
{
    [SerializeField] private GameObject[] players;
    private int currentPlayer = 0;

    void Start()
    {
        currentPlayer = PlayerPrefs.GetInt("CurrentPlayer");
        GameObject player =  Instantiate(players[currentPlayer], gameObject.transform);
        player.SetActive(true);
    }

    
}
