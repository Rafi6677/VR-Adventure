using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SimulationChoiceManager : MonoBehaviour {

    public Button backToMainMenuButton;
    public Button demoSimulationButton;

    public void DemoSimulationButtonOnClick()
    {
        SceneManager.LoadScene("DemoSimulationScene");
    }

    public void BackToMainMenuButtonOnClick()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}
