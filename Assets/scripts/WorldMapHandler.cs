using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldMapHandler : MonoBehaviour {

    public GameObject[] Levelspots;

    public static int currentLevel = 0;
    public static int highestLevel;
   

    public bool firstTime = true;


    // Use this for initialization
    void Start () {

        // this is run only first time when world map is loaded
        if(firstTime == true)
        {
            // first all levels are locked
            UnenableAllLevels();
            ChangeVisibilityOfLevel(0, true);
            firstTime = false;
        }
        
        ShowEnabledLevels();

        
	}
	
	// Update is called once per frame
	void Update () {
        

    }



    // this funtion is called every time to load new level scene from touchcontrols
    public void LoadLevel(int level)
    {

        // Loading scene 1 which is fruit picking game
        SceneManager.LoadScene(3);                                 //<------ Here you can change which scene is loaded when level is loaded
        
        // current level is set
        currentLevel = level;
    }

    // Unenable or enable all components of levelspot in world view
    public void ChangeVisibilityOfLevel(int level, bool status)
    {
        
        Levelspots[level].SetActive(status);
    }


    // unenable all components of levelspots to hide them i world view
    public void UnenableAllLevels()
    {
        for (int i = 0; i < Levelspots.Length; i++)
        {
            ChangeVisibilityOfLevel(i, false);
        }
        
    }

    
    // show all levels up to higest level so far
    public void ShowEnabledLevels()
    {
        for (int i = 0; i < highestLevel; i++)
        {
            
            ChangeVisibilityOfLevel(i, true);
        }
    }
}
