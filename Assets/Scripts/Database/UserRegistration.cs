using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UserRegistration : MonoBehaviour {

    private string name;
    private string login;
    private string email;
    private string password;
    private int age;
    private string sex;

    private string notificationText;
    private bool registrationSuccess;

    public void setVariables(string name, string login, string email, string password, string age, string sex)
    {
        this.name = name;
        this.login = login;
        this.email = email;
        this.password = password;
        this.age = int.Parse(age);
        this.sex = sex;
    }

    public void callRegistration()
    {
        notificationText = "Rejestracja zakończona sukcesem";
        StartCoroutine(Register());
    }

    public string getNotificationText()
    {
        return notificationText;
    }

    public bool isRegistrationSuccess()
    {
        return registrationSuccess;
    }

    IEnumerator Register()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", name);
        form.AddField("login", login);
        form.AddField("email", email);
        form.AddField("password", password);
        form.AddField("age", age);
        form.AddField("sex", sex);

        WWW www = new WWW("http://localhost/VRAdventure/register.php", form);
        yield return www;

        if(www.text == "0")
        {
            notificationText = "Rejestracja zakończona sukcesem!";
            registrationSuccess = true;
            Debug.Log(notificationText);

            DBManager.username = login;
            SceneManager.LoadScene("MainMenuScene");
        }
        else
        {
            notificationText = "Rejestracja zakończona niepowodzeniem! Error: " + www.text;
            registrationSuccess = false;
            Debug.Log(notificationText);
        }
    }

 
}
