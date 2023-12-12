using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManger : MonoBehaviour
{
    public static int health;
    public static int maxhealth = 3;
    public Animator animator;


    public Image[] hearts;

    public Sprite fullHeart;
    public Sprite emptyHeart;

    void Start()
    {
        health = maxhealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Time.timeScale = 0;

            Destroy(gameObject);

            //GameObject.Find("RetryButton").GetComponent<lostscripe>().Addpoints();
        }
        foreach (Image img in hearts)
        {
            img.sprite = emptyHeart;
        }
        for (int i = 0; i < health; i++)
        {
            hearts[i].sprite = fullHeart;

        }
    }


}
