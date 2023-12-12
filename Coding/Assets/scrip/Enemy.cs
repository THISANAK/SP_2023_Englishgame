using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;
    public static int checkwin = 0; // เช็คว่าชนะ
    public static int checklose = 0; // เช็คว่าเเพ้ 

    // bool move = true;
    // bool Hit = false;
    // bool Die = false;
    // bool Attrak = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (checkwin != 0)
        {
            Attack();
            checkwin = 0;
        }
        if (checklose != 0)
        {
            hit();
            checklose = 0;
        }
    }
    void Attack()
    {
        animator.SetTrigger("doAttack");
    }
    void hit()
    {
        animator.SetTrigger("doHit");
    }
}
