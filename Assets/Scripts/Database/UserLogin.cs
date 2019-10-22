using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UserLogin : MonoBehaviour {

    private string login;
    private string password;

    private int loginSuccess;

    public void SetVariables(string login, string password)
    {
        this.login = login;
        this.password = password;
        loginSuccess = 1;
    }

    public int IsUserLoggedIn()
    {
        return loginSuccess;
    }

    public void callLogin()
    {
        StartCoroutine(Login());
    }

    IEnumerator Login()
    {
        WWWForm form = new WWWForm();
        form.AddField("login", login);
        form.AddField("password", password);

        WWW www = new WWW("http://localhost/VRAdventure/login.php", form);
        yield return www;

        if (www.text[0] == '0')
        {
            loginSuccess = 1;

            DBManager.username = login;
            SceneManager.LoadScene("MainMenuScene");
        }
        else
        {
            loginSuccess = 2;
            Debug.Log("Logowanie zakończone niepowodzeniem! Error: " + www.text);
        }
    }
}
