using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heroControlScript : MonoBehaviour
{

    private float speed;
    private float jumpingForce;

    //0 = left, 1 = right
    private float direction;
    private bool inAir;
    private bool okToMove;

    void Start()
    {
        this.speed = 3f;
        this.jumpingForce = 300f;
        this.direction = 1;
        this.inAir = true;
        this.okToMove = true;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow) && okToMove)
        {
            if (this.direction != 1)
            {
                this.GetComponent<Transform>().Rotate(0f, 180f, 0f);
                this.direction = 1;
            }
            this.GetComponent<Transform>().Translate(this.speed * Time.deltaTime, 0f, 0f);

            if (inAir == false)
            {
                this.GetComponent<Animator>().Play("heroineAnimation");
            }
        }


        if (Input.GetKey(KeyCode.LeftArrow) && okToMove)
        {
            if (this.direction != 0)
            {
                this.GetComponent<Transform>().Rotate(0f, 180f, 0f);
                this.direction = 0;
            }
            this.GetComponent<Transform>().Translate(this.speed * Time.deltaTime, 0f, 0f);

            if (inAir == false)
            {
                this.GetComponent<Animator>().Play("heroineAnimation");
            }
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            this.GetComponent<Animator>().Play("heroineIdleAnimation");
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && inAir == false && okToMove)
        {
            this.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f,1f) * this.jumpingForce);
        }
    }


    void OnTriggerEnter2D(Collider2D otherObject)
    {
        this.inAir = false;
        this.GetComponent<Animator>().Play("heroineIdleAnimation");
    }
    void OnTriggerExit2D(Collider2D otherObject) 
    {
        this.inAir = true;
        this.GetComponent<Animator>().Play("heroineJumpAnimation");
    }

    public void stopMovement()
    {
        this.okToMove = false;
        this.GetComponent<Rigidbody2D>().isKinematic = true;
        this.GetComponent<Animator>().enabled = false;
        this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
    }
}
