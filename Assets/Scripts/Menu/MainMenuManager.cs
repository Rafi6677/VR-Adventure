using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour {

    public Text currentUsernameText;

    public Button startSimulationButton;
    public Button tutorialButton;
    public Button optionsButton;
    public Button aboutAppButton;
    public Button exitButton;
    public Button logOutButton;

    void Start ()
    {
		if (DBManager.isUserLoggedIn)
        {
            currentUsernameText.text = DBManager.username;
        }
        else
        {
            Debug.Log("User login failed!");
        }
	}
	
	
	void Update ()
    {
		
	}

    public void StartSimulationButtonOnClick()
    {
        SceneManager.LoadScene("QuestionnaireBeforeSimuationScene");      
    }

    public void AboutAppButtonOnClick()
    {
        SceneManager.LoadScene("AboutAppScene");
    }

    public void LogOutButtonOnClick()
    {
        DBManager.username = null;
        SceneManager.LoadScene("RegisterLoginScene");
    }
}
