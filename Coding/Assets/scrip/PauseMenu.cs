using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    private AudioSource SourceClick;

    public GameObject PausePanel; //เรียก PausePanel
    //public GameObject QuitPanel; // เรียก QuitPanel
    // Update is called once per frame
    void Update()
    {
       

    }
    //หยุดเวลา ใช้ ปุ่ม Setting เรียก
    public void Pause()
    {
        SourceClick.Play();
        PausePanel.SetActive(true);
        Time.timeScale = 0;

    }

    //ใช้ปุ่ม Play เล่นต่อ
    public void Resume()
    {
        
        PausePanel.SetActive(false);
        
        Time.timeScale = 1;
        

    }
    //ออกจากเกม
    public void Quit()
    {
        
        Debug.Log("Quitting game...");
       
        Application.Quit();
    }

    //ใช้ปุ่ม No เรียก อยู่ใน QuitPanel
    public void Return()
    {

        //QuitPanel.SetActive(false);//ปิด QuitPanel
        Time.timeScale = 0;
        SourceClick.Play();

    }

}


