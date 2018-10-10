﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour {

    Image timerBar;
    public float maxTime = 5f;
    float timeLeft;
   

	void Start () {
        
        timerBar = GetComponent<Image>();
        timeLeft = maxTime;
	}
	
	
	void Update () {
		if(timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            timerBar.fillAmount = timeLeft / maxTime;
        }
        else
        {
            SceneManager.LoadScene("Scene1");
            
        }
	}
    public void StartGame()
    {
        SceneManager.LoadScene("Time-Loading");
    }
}
