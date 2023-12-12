using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scence : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
        
    }

    public void QuizPlay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
    public void OpenScene(string Namelevel)
    {
        string Namestage = Namelevel;

        SceneManager.LoadScene(Namestage);
    }

}
