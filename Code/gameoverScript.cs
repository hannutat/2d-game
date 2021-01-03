using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameoverScript : MonoBehaviour
{

    private GameObject scoreText;
    
    void Start()
    {
        this.scoreText = GameObject.Find("scoreText");
        this.scoreText.GetComponent<Text>().text = "Your score : " + PlayerPrefs.GetInt("score").ToString();
    }
    
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Return))
        {
            SceneManager.LoadScene(1);
        }

        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
