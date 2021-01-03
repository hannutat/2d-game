using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinScript : MonoBehaviour
{

    private GameObject gameScript;
    public GameObject burst;

    void Start()
    {
        this.gameScript = GameObject.Find("gameCodeObject");
    }


    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name == "hero")
        {
            GameObject coinBurst = Instantiate(this.burst, this.GetComponent<Transform>().position, Quaternion.identity);
            Destroy(coinBurst.gameObject, 2f);
            Destroy(this.gameObject);
            this.gameScript.GetComponent<gameCodeScript>().scoreACoin();
        }

        if (collider.gameObject.layer == 10)
        {
            this.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-2f, 1f),1f) * 300f);
        }
    }

    public void stopMovement()
    {
        this.GetComponent<Animator>().enabled = false;
        this.GetComponent<Rigidbody2D>().isKinematic = true;
        this.GetComponent<Animator>().enabled = false;
        this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
    }

}
