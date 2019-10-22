using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AboutAppManager : MonoBehaviour {

    public Button backToMenuButton;

    public void BackToMenuButtonOnClick()
    {
        SceneManager.LoadScene("MainMenuScene");
    }

}
