﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockBehavior : MonoBehaviour
{
    public float speed;
    public GameObject square;
    private bool spacePressed = false;

    private float timeToRoof = 2f;
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Rigidbody2D>().gravityScale = 0; 
    }

    // Update is called once per frame
    void Update()
    {
        if (spacePressed == false)
        {
            this.GetComponent<Transform> ().Translate (new Vector3 (speed, 0));
        }
        else
        {
            timeToRoof -= Time.deltaTime;
            if (timeToRoof <= 0)
            {
                var newSquare = Instantiate(square, new Vector3(0, 4.7f, 0), Quaternion.identity);
                newSquare.transform.localScale += new Vector3(-5, 0, 0);
                timeToRoof = 100000f;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.GetComponent<Rigidbody2D>().gravityScale = 1;
            spacePressed = true;
        }
    }
    
    void OnCollisionEnter2D(Collision2D collision) //when you collide with enemy
    {
        if (collision.gameObject.tag.Equals("wall"))
        {
            speed = -speed;
        }
    }
}
