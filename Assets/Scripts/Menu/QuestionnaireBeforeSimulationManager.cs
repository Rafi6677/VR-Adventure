using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuestionnaireBeforeSimulationManager : MonoBehaviour {

    public Toggle questionOneNOToggle;
    public Toggle questionOneYESToggle;

    public Toggle questionTwoNOToggle;
    public Toggle questionTwoYESToggle;

    public Toggle questionThreeNOToggle;
    public Toggle questionThreeYESToggle;

    public InputField questionFourAnswerInputField;

    public Button continueButton;
    public Button backToMainMenuButton;

    public QuestionnaireBeforeSimulationAnswersUpload answersUploadScript;


    public void ContinueButtonOnClick()
    {
        string questionOneAnswer;
        string questionTwoAnswer;
        string questionThreeAnswer;
        string questionFourAnswer;
        
        if (questionOneYESToggle.GetComponent<Toggle>().isOn) questionOneAnswer = "yes";
        else questionOneAnswer = "no";

        if (questionTwoYESToggle.GetComponent<Toggle>().isOn) questionTwoAnswer = "yes";
        else questionTwoAnswer = "no";

        if (questionThreeYESToggle.GetComponent<Toggle>().isOn) questionThreeAnswer = "yes";
        else questionThreeAnswer = "no";

        questionFourAnswer = questionFourAnswerInputField.text;

        answersUploadScript.SetVariables(questionOneAnswer, questionTwoAnswer, questionThreeAnswer, questionFourAnswer);

        answersUploadScript.SendAnswersToServer();
    }

    public void BackToMainMenuButtonOnClick()
    {
        SceneManager.LoadScene("MainMenuScene");
    }

}
