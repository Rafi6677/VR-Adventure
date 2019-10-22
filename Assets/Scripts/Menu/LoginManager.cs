using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginManager : MonoBehaviour {

    public GameObject registrationCanvas;
    public GameObject loginCanvas;

    public InputField loginLoginInput;
    public InputField passwordLoginInput;

    public Button loginUserButton;
    public Button goToRegistrationButton;

    public UserLogin userLogin;

    void Start()
    {
        
    }

    public void VerifyInputs()
    {
        loginUserButton.interactable = (loginLoginInput.text.Length > 0 && passwordLoginInput.text.Length > 0);
    }

    public void LoginButtonOnClick()
    {
        userLogin.SetVariables(loginLoginInput.text, passwordLoginInput.text);
        userLogin.callLogin();
    }

    public void BackToRegistrationButtonOnClick()
    {
        loginCanvas.SetActive(false);
        registrationCanvas.SetActive(true);
    }

    IEnumerator waitOneSecond()
    {
        yield return new WaitForSeconds(1);
    }
}
