using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class QuestionManager : MonoBehaviour
{
    public List<QuestionAndAnswer> QnA;
    public GameObject[] option;
    public int currentQuestion;

    public GameObject Quizpanal;
    public GameObject GoPanel;


    public Text QuestionTxt;

    public Text ScoreTxt;

    int totalQuestions = 0;
    public int score;
    private void Start()
    {
        totalQuestions = QnA.Count;
        GoPanel.SetActive(false);
        generateQuestion();
    }
    
    public void retry()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);


    }

   

    void GameOver()
    {
        
        Quizpanal.SetActive(false);
        GoPanel.SetActive(true);
        ScoreTxt.text = score + "/" + totalQuestions;
        



    }

    public void correct()
    {
        score += 1;
       
        QnA.RemoveAt(currentQuestion);
        generateQuestion();
       
    }

    public void wrong()
    {
        QnA.RemoveAt(currentQuestion);
        generateQuestion();
        
    }


    void SetAnswer()
    {
        for (int i = 0; i < option.Length; i++)
        {
            option[i].GetComponent<AnswerQnA>().isCorrect = false;
            option[i].transform.GetChild(0).GetComponent<Text>().text = QnA[currentQuestion].Answes[i];
            if (QnA[currentQuestion].CorrectAnswer == i + 1)
            {
                option[i].GetComponent<AnswerQnA>().isCorrect = true;
            }
        }
    }
    

        void generateQuestion()

    {

        if (QnA.Count > 0)
        {

            QuestionTxt.text = QnA[currentQuestion].Question;
            
            SetAnswer();
        }
        else
        {
            Debug.Log("Out of Question");
            
            GameOver();

        }
    }


    public void NextScence()
    {
        int currentLavel = SceneManager.GetActiveScene().buildIndex;
        if(currentLavel >= PlayerPrefs.GetInt("Unlockedlevel") )
        {
            PlayerPrefs.SetInt("Unlockedlevel", currentLavel + 1);
            PlayerPrefs.Save();

            
        }
        //Debug.Log("Level " + PlayerPrefs.GetInt("Unlockedlevel") + " UNLOCK");

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1 );
    }
   




}
