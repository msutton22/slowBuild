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
    public int spacePressedNum;
    public GameObject square;
    public GameObject camera;
    public GameObject scoreText;
    public AudioSource sound1;
    
    private bool spacePressed = false;

    private float timeToRoof = 2f;

    private float yCom;
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Rigidbody2D>().gravityScale = 0;
        yCom = this.GetComponent<Transform>().position.y;
        if (spacePressedNum == 2)
        {
            transform.localScale -= new Vector3(0.04f, 0f, 0);
        }
        else if (spacePressedNum == 4)
        {
            speed = 0.08f;
        }
        else if (spacePressedNum == 6)
        {
            transform.localScale -= new Vector3(0.04f, 0f, 0);
        }
        else if (spacePressedNum == 8)
        {
            speed = 0.12f;
        }
        else if (spacePressedNum == 10)
        {
            transform.localScale -= new Vector3(0.04f, 0f, 0);
        }
        else if (spacePressedNum == 12)
        {
            speed = 0.18f;
        }
        else if (spacePressedNum == 14)
        {
            transform.localScale -= new Vector3(0.04f, 0f, 0);
        }
        else if (spacePressedNum == 16)
        {
            speed = 0.22f;
        }
        else if (spacePressedNum == 18)
        {
            transform.localScale -= new Vector3(0.04f, 0f, 0);
        }
        else if (spacePressedNum == 20)
        {
            speed = 0.26f;
        }
        else if (spacePressedNum == 23)
        {
            transform.localScale -= new Vector3(0.08f, 0f, 0);
        }
        else if (spacePressedNum == 25)
        {
            speed = 0.3f;
        }
        else if (spacePressedNum == 28)
        {
            transform.localScale -= new Vector3(0.08f, 0f, 0);
        }
        else if (spacePressedNum == 32)
        {
            speed = 0.35f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.gameObject.GetComponent<Text>().text = ("Number of Stories: " + score);
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
            spacePressedNum += 1;
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
            sound1.Play();
        }
        if (collision.gameObject.tag.Equals("floor"))
        {
            SceneManager.LoadScene (1);
        }
        if (collision.gameObject.tag.Equals("bird"))
        {
            Destroy(collision.gameObject);
        }
    }
}
