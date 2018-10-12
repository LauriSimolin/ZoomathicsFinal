using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Menu()
    {
        SceneManager.LoadScene(0);
    }

    void Login()
    {
        SceneManager.LoadScene(1);
    }

    void MapView()
    {
        SceneManager.LoadScene(2);
    }


    
}
