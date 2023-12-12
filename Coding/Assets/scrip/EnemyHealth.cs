using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnemyHealth : MonoBehaviour
{
    public static int emhealth;
    public static int maxemhealth = 5;

    public Image[] emhearts;
    public Image[] gotsh;
    public Sprite emfullHeart;
    public Sprite ememptyHeart;


    void Start()
    {
        emhealth = maxemhealth;
    }
    // Update is called once per frame
    void Update()
    {
        if (emhealth <= 0)
        {
            
            

        }
        foreach (Image img in emhearts)
        {
            img.sprite = ememptyHeart;
        }
        for (int i = 0; i < emhealth; i++)
        {
            emhearts[i].sprite = emfullHeart;
        }
    }
}
