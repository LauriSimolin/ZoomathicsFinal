using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameHandler : MonoBehaviour {

    public static int picks;
    public int answer;
    public Text problemtext;

    public Text scoretext;
    public int score;
    public int scoreToPass;

    private bool submitted;
    private bool levelcomplete;
    

    // initializing delay time, how much is waited after submitting answer before going to next scene
    public float timer = 2f;
    private float currentTime;

    public GameObject spawner;
    
    
    

    
    
	// Use this for initialization
	void Start () {
        spawner = FindObjectOfType<FruitSpawner>().gameObject;
        //worldHandler = FindObjectOfType<WorldMapHandler>().gameObject;

        LoadProblem();
	}
	
	// Update is called once per frame
	void Update () {
        
        // incrementing timer
        currentTime -= Time.deltaTime;

        // displaying current score on the screen and score to pass level
        scoretext.text = "Score: " + score.ToString()+ "/" + scoreToPass.ToString();

        if(currentTime <= 0 && score >= scoreToPass)
        {
            // we want to test if current level is smaller than higest level to increment highest level
            // only if player makes progress in game
            if (WorldMapHandler.highestLevel <= WorldMapHandler.currentLevel)
            {
                WorldMapHandler.highestLevel = WorldMapHandler.currentLevel + 1;
            }
                

             // after finnishing level we load worldmap again
             SceneManager.LoadScene(0);                                  //< ---here you want to add loading of the next scene
        }

        // if right answer is submitted                              
        if (currentTime <= 0 && levelcomplete == true && score < scoreToPass)        
        {
            currentTime = timer;
            //Debug.Log("Level complete, load next scene");
            
            // before loading new level we want to enable touchcontrols
            TouchControls.touchEnabled = true;
            
            // Loading next problem for the level
            LoadProblem();
        }
        // if answer is submitted with wrong answer
        if(currentTime <= 0 && levelcomplete == false && submitted == true)
        {
            currentTime = timer;
            //Debug.Log("timer run out, submitted wrong answer");

            // reset score before new try
            score = 0;
            
            // before loading new level we want to enable touchcontrols
            TouchControls.touchEnabled = true;
            
            // Loading next problem for the level
            LoadProblem();

        }

        // timer is reset every time it runs out
        if (currentTime <= 0)
        {
            currentTime = timer;
        }



    }
    // Here we load problem for each level                          <----TODO Here we want to add more parameters for level creation
    void LoadProblem()
    {
        if(WorldMapHandler.currentLevel == 1)
        {
            CreateProblem(3, 2);
        }
        if (WorldMapHandler.currentLevel == 2)
        {
            CreateProblem(5, 3);
        }

    }

    // Creation of a problem fir the current level
    public void CreateProblem(int fruits, int pass)
    {
        // initializing parameters
        picks = 0;
        scoreToPass = pass;
        currentTime = timer;
        submitted = false;
        levelcomplete = false;
        
        

        // randomizing the answer
        answer = Random.Range(1, fruits+1);
        
        // printing question text to UI
        problemtext.text = "Pick " + answer.ToString() + " fruits for animal";

        // we want to clear window of fruits
        spawner.GetComponent<FruitSpawner>().DestroyAllFruits();

        // call Spawn() function of the fruitspawner class
        spawner.GetComponent<FruitSpawner>().Spawn(fruits);
    }



    // functions is called when submit button is pressed
    public void SubmitAnswer()
    {
        // reset timer to give player some time to see results
        currentTime = timer;
        // after submitting we want to unenable touch controls
        TouchControls.touchEnabled = false;

        if (answer == picks)
        {
            // winning condition
            problemtext.text = "CORRECT!";
            levelcomplete = true;
            score += 1;


        }
        else if (answer > picks)
        {
            // loosing condition, too few
            problemtext.text = "FAIL, too few fruits!";
            submitted = true;
        }
        else if (answer < picks)
        {
            // loosing condition, too many
            problemtext.text = "FAIL, too many fruits!";
            submitted = true;
        }


        
    }

    public void LoadMapView()
    {
        SceneManager.LoadScene(0);
    }
}
