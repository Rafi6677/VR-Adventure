using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RegistrationManager : MonoBehaviour {

    public GameObject registrationCanvas;
    public GameObject loginCanvas;

    public InputField nameRegistrationInput;
    public InputField loginRegistrationInput;
    public InputField emailRegistrationInput;
    public InputField passwordRegistrationInput;
    public InputField ageRegistrationInput;
    public Toggle manRegistrationToggle;
    public Toggle womanRegistrationToggle;

    public Button registerUserButton;
    public Button goToLoginButton;

    public UserRegistration userRegistration;

    void Start ()
    {
        registrationCanvas.SetActive(true);
        loginCanvas.SetActive(false);

        womanRegistrationToggle.isOn = true;
        manRegistrationToggle.isOn = false;
	}

    public void VerifyInputs()
    {
        registerUserButton.interactable = 
            (nameRegistrationInput.text.Length > 0 && 
            loginRegistrationInput.text.Length > 0 && 
            emailRegistrationInput.text.Length > 0 &&
            passwordRegistrationInput.text.Length > 0 && 
            ageRegistrationInput.text.Length > 0);
    }

    public void RegistrationButtonOnClick()
    {
        string sex;
            
        if (manRegistrationToggle.GetComponent<Toggle>().isOn)
        {
            sex = "male";
        }
        else
        {
            sex = "female";
        }

        userRegistration.setVariables(nameRegistrationInput.text,
            loginRegistrationInput.text,
            emailRegistrationInput.text,
            passwordRegistrationInput.text,
            ageRegistrationInput.text,
            sex);

        userRegistration.callRegistration();
    }

    public void GoToMainMenuButtonOnClick()
    {
        SceneManager.LoadScene("MainMenuScene");
    }

    public void CancelRegistrationButtonOnClick()
    {
        registrationCanvas.SetActive(true);
        loginCanvas.SetActive(false);
    }

    public void GoToLoginButtonOnClick()
    {
        registrationCanvas.SetActive(false);
        loginCanvas.SetActive(true);
    }

    IEnumerator waitOneSecond()
    {
        yield return new WaitForSeconds(1);
    }
}
