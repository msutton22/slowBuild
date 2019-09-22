using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class end : MonoBehaviour
{
    private int score;
    public Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: " + (PlayerPrefs.GetFloat ("Score")).ToString(); //changing text of the score text
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
