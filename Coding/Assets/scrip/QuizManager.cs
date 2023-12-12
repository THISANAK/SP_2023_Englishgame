using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{
    public static QuizManager instance; //Instance to make is available in other scripts without reference

    
    [SerializeField]
    private AudioSource SourceClick;
    [SerializeField]
    private AudioSource SourceRemove;
    [SerializeField]
    private AudioSource SourceCorrect;
    [SerializeField]
    private AudioSource SourceWrong;
    [SerializeField]
    private QuizDataScriptable questionsData;
    [SerializeField]
    private Text questionText;
    [SerializeField]
    private GameObject Playedgame;
    [SerializeField]
    private GameObject RetryPanel;
    [SerializeField]
    private GameObject GameOver;
    [SerializeField] 
    private WordData[] Drop_PanelArray;     //list of answers word in the game
    [SerializeField] 
    private WordData[] optionArray;   //list of options word in the game
    [SerializeField] 
    private char[] charArray = new char[9];
    
    private int currentDropIndex = 0;
    private bool correctAnswer = true;
    private List<int> selectedWordIndex;
    private int currrentQuestionInddex = 0;
    private GameStatus gameStatus = GameStatus.Playing;
    private string answerWord;
    



    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
        selectedWordIndex = new List<int>();
    }

    private void Start()
    {
        SetQuestion();
        GameOver.SetActive(false);
        RetryPanel.SetActive(false);
        Time.timeScale = 1;

    }
    private void Update()
    {


        
    }

    private void SetQuestion()
    {
        HealthManger.health = 3;

        currentDropIndex = 0;
        selectedWordIndex.Clear();
       

        questionText.text = questionsData.questions[currrentQuestionInddex].questionText;
        answerWord = questionsData.questions[currrentQuestionInddex].answer;
        ResetQuestion();

        for (int i = 0; i < answerWord.Length; i++)
        {
            charArray[i] = char.ToUpper(answerWord[i]);
        }
        for (int i = answerWord.Length; i< optionArray.Length; i++)
        {
            charArray[i] = (char)UnityEngine.Random.Range(65, 91);
        }
        charArray = ShuffleList.ShuffleListItems<char>(charArray.ToList()).ToArray();
        for (int i = 0; i < optionArray.Length; i++)
        {
            optionArray[i].SetWord(charArray[i]);
        }

        currrentQuestionInddex++;
        gameStatus = GameStatus.Playing;
    }

public void SelectedOption(WordData wordData)

        

{
        if (gameStatus == GameStatus.Next || currentDropIndex >= answerWord.Length)
        {
           
            return;
            
        }
        selectedWordIndex.Add(wordData.transform.GetSiblingIndex());
        Drop_PanelArray[currentDropIndex].SetWord(wordData.charValue);
        wordData.gameObject.SetActive(false);
        currentDropIndex++;
        SourceClick.Play();
        if (currentDropIndex >= answerWord.Length)
        {
            correctAnswer = true;
        }
        for (int i = 0; i < answerWord.Length; i++)
        {
            if (char.ToUpper(answerWord[i]) != char.ToUpper(Drop_PanelArray[i].charValue))
            {
                correctAnswer = false;
                break;


            }
        }

        
}
    private void ResetQuestion()
    {
        {
            //activate all the answerWordList gameobject and set their word to "_"
            for (int i = 0; i < Drop_PanelArray.Length; i++)
            {
                Drop_PanelArray[i].gameObject.SetActive(true);
                Drop_PanelArray[i].SetWord('_');
            }

            //Now deactivate the unwanted answerWordList gameobject (object more than answer string length)
            for (int i = Drop_PanelArray.Length; i <    Drop_PanelArray.Length; i++)
            {
                Drop_PanelArray[i].gameObject.SetActive(false);
            }

            //activate all the optionsWordList objects
            for (int i = 0; i < optionArray.Length; i++)
            {
                optionArray[i].gameObject.SetActive(true);
            }

            currentDropIndex = 0;
            


        }

    }
    public void ResetLastWord()//remove button
    {
        if (selectedWordIndex.Count > 0)
        {
            int index = selectedWordIndex[selectedWordIndex.Count - 1];
            optionArray[index].gameObject.SetActive(true);
            selectedWordIndex.RemoveAt(selectedWordIndex.Count - 1);
            currentDropIndex--;
            Drop_PanelArray[currentDropIndex].SetWord('_');
            SourceRemove.Play();
        }
    }

    public void Check()//check Answer
    {
        SourceClick.Play();
        if (currentDropIndex >0) {
            if (correctAnswer)
            {

                Debug.Log("We have answer correct");
                EnemyHealth.emhealth--;
                SourceCorrect.Play();
                SourceClick.Pause();
                gameStatus = GameStatus.Next;
                Pllayer.checkwin++; // เช็คว่าชนะ
                Enemy.checklose++;




                if (currrentQuestionInddex < questionsData.questions.Count)
                {
                    Invoke("SetQuestion", 0.5f);
                }
                else
                {
                    GameOver.SetActive(true);
                    Time.timeScale = 0;

                    Playedgame.SetActive(false);


                }
            }
            else if (!correctAnswer)
            {
                Debug.Log("We have answer incorrect");
                ResetQuestion();
                HealthManger.health--;
                SourceWrong.Play();
                Pllayer.checklose++; // เช็คว่าแพ้
                Enemy.checkwin++;
                if (HealthManger.health <= 0)
                {

                    RetryPanel.SetActive(true);

                }
            }
        }        
    }

    public void retry()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;

    }
   







}



[System.Serializable]
public class QuestionData
{
    public string questionText;
    public string answer;
}

public enum GameStatus
{
    Playing,
    Next
}