using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour {

    Image timerBar;
    public float maxTime;
    float timeLeft;

    float timer;
    float currentTime;

    

    public GameObject timerbarprefab;
    

    public Text problemtext;
    
   

	void Start () {
        
        GameObject newTimerBar = Instantiate(timerbarprefab, timerbarprefab.transform.position, Quaternion.identity) as GameObject;
        newTimerBar.transform.SetParent(GameObject.FindGameObjectWithTag("timerbar").transform, false);


        maxTime = 50f;
        timerBar = newTimerBar.GetComponent<Image>();
        
        
        timeLeft = maxTime;
        timer = 1f;
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
            if (currentTime <= 0)
            {

                SceneManager.LoadScene(3);
            }


        }
	}
    //public void StartGame()
    //{
    //    SceneManager.LoadScene("Time-Loading");
    //}

    public void TimeOut()
    {
        problemtext.text = "Time run out, try again.";
    }
}
