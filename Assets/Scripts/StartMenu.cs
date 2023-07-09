using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    public Text HStext;
    // Start is called before the first frame update
    void Start()
    {
        HStext.text = "Hight Score: " + PlayerPrefs.GetInt("hightscore");
    }
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
