using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class roofScript : MonoBehaviour
{
    public GameObject scoreText;
    public GameObject block;
    public int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       // scoreText.GetComponent<Text>().text 
        scoreText.gameObject.GetComponent<Text>().text = ("Score: " + score);
    }
    
    void OnCollisionEnter2D(Collision2D collision) //when you collide with enemy
    {
        if (block.gameObject.tag.Equals("Block"))
        {
            score += 1;
        }
    }
}