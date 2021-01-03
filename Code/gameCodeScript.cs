using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameCodeScript : MonoBehaviour
{
    private int coinCount;
    private int currentScore;
    private int birdCount;
    private int birdCountMax;
    private int birdCountMaxOld;
    public GameObject coin;
    private GameObject scoreUI;
    public GameObject bird;
    private GameObject soundfx;
    private GameObject[] coinArr;
    private GameObject[] gameCharArr;
    private bool playerDead;
    private float deathTimer;

    void Start()
    {
        this.scoreUI = GameObject.Find("Score");
        this.coinCount = 5;
        this.currentScore = 0;
        this.birdCount = 0;
        this.birdCountMax = 1;
        this.soundfx = GameObject.Find("soundFX");
        this.playerDead = false;
        this.deathTimer = 0f;
    }


    void Update()
    {
        this.birdCountMaxOld = this.birdCountMax;
        this.birdCountMax = currentScore / 5;

        if (this.birdCountMax < 1)
        {
            this.birdCountMax = 1;
            this.birdCountMaxOld = 1;
        }

        if (this.birdCountMax > this.birdCountMaxOld)
        {
            this.soundfx.GetComponents<AudioSource>()[1].Play();
        }

        if (birdCount < birdCountMax)
        {
            GameObject newBird = Instantiate(this.bird, new Vector3(0f, -7f), Quaternion.identity);
        }

        this.coinCount = GameObject.FindGameObjectsWithTag("coin").Length;

        if (this.coinCount < 10)
        {
            GameObject newCoin = Instantiate(this.coin, new Vector3(Random.Range(-8f, 9f), Random.Range(-3f, 5f)), Quaternion.identity);
        }

        if (playerDead)
        {
            deathTimer += Time.deltaTime * 1f;
            if (deathTimer > 2f)
            {
                SceneManager.LoadScene(2);
            }
        }

        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void scoreACoin()
    {
        this.currentScore++;
        this.scoreUI.GetComponent<Text>().text = "Score: " + this.currentScore;
    }

    public void birdCounterUp()
    {
        this.birdCount++;
    }

    public void birdCounterDown()
    {
        this.birdCount--;
    }

    public void gameOver()
    {
        PlayerPrefs.SetInt("score", this.currentScore);
        this.gameCharArr = GameObject.FindGameObjectsWithTag("gamechar");
        this.coinArr = GameObject.FindGameObjectsWithTag("coin");

        foreach (GameObject gamechar in gameCharArr)
        {
            if (gamechar.layer == 9)
            {
                gamechar.GetComponent<evilbirdScript>().stopMovement();
            }
            if (gamechar.name == "hero")
            {
                gamechar.GetComponent<heroControlScript>().stopMovement();
            }
        }

        foreach (GameObject coin in coinArr)
        {
            coin.GetComponent<coinScript>().stopMovement();
        }

        this.soundfx.GetComponents<AudioSource>()[0].Play();
        this.playerDead = true;
    }
}
