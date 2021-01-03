using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class evilbirdScript : MonoBehaviour
{
    private float speed;
    private float direction;
    private GameObject gameScript;
    private bool okToMove;

    void Start()
    {
        this.okToMove = true;
        this.gameScript = GameObject.Find("gameCodeObject");
        this.gameScript.GetComponent<gameCodeScript>().birdCounterUp();

        //0 = to the right, 1 = to the left
        this.direction = Random.Range(0, 2);

        this.speed = Random.Range(1f, 5f);

        if (this.direction == 0)
        {
            this.GetComponent<Transform>().position = new Vector3(-9.5f, Random.Range(-3.2f, 4.3f));
        }

        if (this.direction == 1)
        {
            this.GetComponent<Transform>().position = new Vector3(9.5f, Random.Range(-3.2f, 4.3f));
            this.GetComponent<Transform>().Rotate(0f, 180f, 0f);
        }
    }

    void Update()
    {
        if (okToMove)
        {
            this.GetComponent<Transform>().Translate(this.speed * Time.deltaTime, 0f, 0f);
        }

        if (this.direction == 0 && this.GetComponent<Transform>().position.x > 10)
        {
            this.gameScript.GetComponent<gameCodeScript>().birdCounterDown();
            Destroy(this.gameObject);
        }

        if (this.direction == 1 && this.GetComponent<Transform>().position.x < -10)
        {
            this.gameScript.GetComponent<gameCodeScript>().birdCounterDown();
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.name == "hero")
        {
            this.gameScript.GetComponent<gameCodeScript>().gameOver();
        }
    }

    public void stopMovement()
    {
        this.GetComponent<Transform>().Translate(0f, 0f, 0f);
        this.GetComponent<Animator>().enabled = false;
        this.okToMove = false;
    }

}
