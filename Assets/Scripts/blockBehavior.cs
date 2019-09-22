using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.SceneManagement;

public class blockBehavior : MonoBehaviour
{
    public float speed;
    public int score;
    public GameObject square;
    public GameObject camera;
    public GameObject scoreText;
    
    private bool spacePressed = false;

    private float timeToRoof = 2f;

    private float yCom;
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Rigidbody2D>().gravityScale = 0;
        yCom = this.GetComponent<Transform>().position.y;
        //DontDestroyOnLoad (gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.gameObject.GetComponent<Text>().text = ("Score: " + score);
        if (spacePressed == false)
        {
            this.GetComponent<Transform> ().Translate (new Vector3 (speed, 0));
        }
        else
        {
            timeToRoof -= Time.deltaTime;
            if (timeToRoof <= 0)
            {
                Instantiate(square, new Vector3(0, yCom + 1f, 0), Quaternion.identity);
                camera.transform.position += Vector3.up * speed * Time.deltaTime;
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
        PlayerPrefs.SetFloat ("Score", score);
        if (collision.gameObject.tag.Equals("wall"))
        {
            speed = -speed;
        }
        if (collision.gameObject.tag.Equals("Block"))
        {
            score += 1;
        }
        if (collision.gameObject.tag.Equals("floor"))
        {
            SceneManager.LoadScene (1);
        }
    }
}
