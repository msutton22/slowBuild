﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class button : MonoBehaviour
{
  
    // Start is called before the first frame update
    void Start()
    {
        //score = GameObject.Find("house").GetComponent<blockBehavior>().score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void PlayGame() {
        SceneManager.LoadScene (0); //if the button is pressed, go to the game
    }
}
