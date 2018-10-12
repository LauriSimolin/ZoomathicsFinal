using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoginScript : MonoBehaviour {

    public GameObject username;
    public GameObject login;

    public Button btnlogin;

    private string Username;


    // Use this for initialization
    void Start () {
        Screen.orientation = ScreenOrientation.Portrait;
	}
	
	// Update is called once per frame
	void Update () {
        //set data to String from input fields
        Username = username.GetComponent<InputField>().text;

        btnlogin = login.GetComponent<Button>();
        btnlogin.onClick.AddListener(validateLogin);
    }
    private void validateLogin()
    {
        if (Username != "")
        {
            print("Login Success");
            SceneManager.LoadScene(2);
        }

    }
}
