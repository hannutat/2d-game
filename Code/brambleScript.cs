using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brambleScript : MonoBehaviour
{

    private GameObject gameScript;


    void Start()
    {
        this.gameScript = GameObject.Find("gameCodeObject");
    }


    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.name == "hero")
        {
            this.gameScript.GetComponent<gameCodeScript>().gameOver();
        }
    }
}
