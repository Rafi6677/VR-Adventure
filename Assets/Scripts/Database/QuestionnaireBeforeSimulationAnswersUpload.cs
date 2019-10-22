using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestionnaireBeforeSimulationAnswersUpload : MonoBehaviour {

    private string questionOneAnswer;
    private string questionTwoAnswer;
    private string questionThreeAnswer;
    private string questionFourAnswer;

    public void SetVariables(string questionOneAnswer, string questionTwoAnswer, 
        string questionThreeAnswer, string questionFourAnswer)
    {
        this.questionOneAnswer = questionOneAnswer;
        this.questionTwoAnswer = questionTwoAnswer;
        this.questionThreeAnswer = questionThreeAnswer;
        this.questionFourAnswer = questionFourAnswer;
    }

    public void SendAnswersToServer()
    {
        StartCoroutine(SendAnswers());
    }

    IEnumerator SendAnswers()
    {
        string date = System.DateTime.UtcNow.ToString("HH:mm dd MMMM, yyyy");

        WWWForm form = new WWWForm();
        form.AddField("date", date);
        form.AddField("username", DBManager.username);
        form.AddField("answerOne", questionOneAnswer);
        form.AddField("answerTwo", questionTwoAnswer);
        form.AddField("answerThree", questionThreeAnswer);
        form.AddField("answerFour", questionFourAnswer);

        WWW www = new WWW("http://localhost/VRAdventure/sendQuestionnaireBeforeSimulation.php", form);
        yield return www;

        if (www.text == "0")
        {
            Debug.Log("Answers updated successfully");
            SceneManager.LoadScene("SimulationChoiceScene");
        }
        else
        {
            Debug.Log("Failed to update answers to server!");
            Debug.Log(www.text);
        }
    
    }
}
