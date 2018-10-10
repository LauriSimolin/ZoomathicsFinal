using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour {

    Image timerBar;
    public float maxTime = 45f;
    float timeLeft;

    float timer = 2f;
    float currentTime;

    public Text problemtext;
    
   

	void Start () {
        
        timerBar = GetComponent<Image>();
        timeLeft = maxTime;

        currentTime = timer;
	}
	
	
	void Update () {
        

		if(timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            timerBar.fillAmount = timeLeft / maxTime;
        }
        else if(GameHandler.levelcomplete == false)
        {

            TimeOut();
            currentTime -= Time.deltaTime;
            if(currentTime <= 0)
            {
                
                SceneManager.LoadScene(3);
            }
            
            
        }
	}
    public void StartGame()
    {
        SceneManager.LoadScene("Time-Loading");
    }

    public void TimeOut()
    {
        problemtext.text = "Time run out, try again.";
    }
}
