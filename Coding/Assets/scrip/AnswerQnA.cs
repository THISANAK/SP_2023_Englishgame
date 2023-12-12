using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerQnA : MonoBehaviour
{
    public bool isCorrect = false;
    public QuestionManager questionManager;

   
      
    public void Answer()
    {

        if (isCorrect)
        {

            Debug.Log("Correct Answer");
            questionManager.correct();

        }
        else
        {
            Debug.Log("Wrong Answer");
            questionManager.wrong();
        }
    }
}
