using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class introScript : MonoBehaviour
{

    private float timer;
    private bool soundIsPlaying;
    private float runningSpeed;
    private bool okToStart;
    private bool titleMove;

    private GameObject title;
    private GameObject info1;
    private GameObject info2;
    private GameObject subtitle;

    private GameObject bird;
    private GameObject log;
    private GameObject bramble;

    private GameObject coin1;
    private GameObject coin2;
    private GameObject coin3;

    private GameObject intro;
    private GameObject hero;
    private GameObject startgame;
    private GameObject controls;

    
    void Start()
    {
        this.timer = 0f;
        this.soundIsPlaying = false;
        this.runningSpeed = 3f;
        this.okToStart = false;
        this.titleMove = true;

        this.title = GameObject.Find("titleText");
        this.info1 = GameObject.Find("info1");
        this.info2 = GameObject.Find("info2");
        this.startgame = GameObject.Find("startGameText");
        this.controls = GameObject.Find("controls");
        this.subtitle = GameObject.Find("subtitle");

        this.bird = GameObject.Find("bird");
        this.log = GameObject.Find("log_long");
        this.bramble = GameObject.Find("bramble");

        this.coin1 = GameObject.Find("coin1");
        this.coin2 = GameObject.Find("coin2");
        this.coin3 = GameObject.Find("coin3");

        this.intro = GameObject.Find("introObject");
        this.hero = GameObject.Find("hero");
    }

   
    void Update()
    {
        if (titleMove)
        {
            this.title.GetComponent<RectTransform>().Translate(0f, Time.deltaTime * -150f, 0f);
            this.subtitle.GetComponent<RectTransform>().Translate(0f, Time.deltaTime * -150f, 0f);
        }

        this.timer += Time.deltaTime * 1f;
        this.hero.GetComponent<Transform>().Translate(this.runningSpeed * Time.deltaTime, 0f, 0f);
        this.hero.GetComponent<Animator>().Play("heroineAnimation");

        if (this.timer > 1.5f)
        {
            if (!soundIsPlaying)
            {
                this.intro.GetComponent<AudioSource>().Play();
                this.soundIsPlaying = true;
            }
            this.title.GetComponent<RectTransform>().Translate(0f, 0f, 0f);
            this.subtitle.GetComponent<RectTransform>().Translate(0f, 0f, 0f);
            this.titleMove = false;
        }

        if (this.timer > 3f)
        {
            this.info1.GetComponent<Text>().enabled = true;
            this.bird.GetComponent<SpriteRenderer>().enabled = true;
            this.bramble.GetComponent<SpriteRenderer>().enabled = true;
            this.log.GetComponent<SpriteRenderer>().enabled = true;
        }

        if (this.timer > 4f)
        {
            this.info2.GetComponent<Text>().enabled = true;
            this.coin1.GetComponent<SpriteRenderer>().enabled = true;
            this.coin2.GetComponent<SpriteRenderer>().enabled = true;
            this.coin3.GetComponent<SpriteRenderer>().enabled = true;
        }

        if (this.hero.GetComponent<Transform>().position.x > 9f)
        {
            this.startgame.GetComponent<Text>().enabled = true;
            this.controls.GetComponent<Text>().enabled = true;
            this.okToStart = true;
        }

        if (okToStart && Input.GetKeyUp(KeyCode.Return))
        {
            SceneManager.LoadScene(1);
        }

        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
