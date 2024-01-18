using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TimeManager : MonoBehaviour
{
    private float totalTime;

    void Start()
    {
        totalTime = 0;
    }


    void Update()
    {
        totalTime += Time.deltaTime;
        //Debug.Log(GetTime());
    }

    public string GetTime()
    {
        int minutes = Mathf.FloorToInt(totalTime / 60f);
        int secondes = Mathf.FloorToInt(totalTime % 60f);

        return minutes + ":" + secondes;
    }
}
