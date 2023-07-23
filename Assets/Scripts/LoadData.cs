using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadData : MonoBehaviour
{

    public void LoadGame()
    {
        int savedCoins = PlayerPrefs.GetInt("PlayerCoins", 0); // Load the saved coins, default to 0 if not present
        float savedPlayerPosX = PlayerPrefs.GetFloat("PlayerPositionX", 0f); // Load the saved player position x, default to 0 if not present
        float savedPlayerPosY = PlayerPrefs.GetFloat("PlayerPositionY", 0f); // Load the saved player position y, default to 0 if not present

        // Set the saved coins and player position
        CoinsCollection.Instance.SetCoins(savedCoins);
        PlayerMovement.Instance.transform.position = new Vector3(savedPlayerPosX, savedPlayerPosY, 0f);

        SceneManager.LoadScene("GameScenes", LoadSceneMode.Single);
    }

}
