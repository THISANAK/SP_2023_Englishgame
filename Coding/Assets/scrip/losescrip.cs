using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class losescrip : MonoBehaviour
{
    private int pointsTolose = 3;
    private int currentPoints = -0;
    






    // Update is called once per frame
    void Update()
    {
        if (currentPoints >= pointsTolose)
        {

            transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    public void Addpoints()
    {

        currentPoints++;
    }
}
