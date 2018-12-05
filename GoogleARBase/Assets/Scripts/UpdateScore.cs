﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//attach this to the hoop
public class UpdateScore : MonoBehaviour {
    private int score = 0;
    //public Text scoreText;
    private Text scoreText;

    // Use this for initialization
    private void Start()
    {

        scoreText = GameObject.FindWithTag("ScoreText").GetComponent<Text>();
        scoreText.text = "Score: " + score.ToString();
    }

    // Update is called once per frame
    private void OnTriggerExit(Collider other)
    {
        score += 1;
        scoreText.text = "Score: " + score.ToString();
    }
}
