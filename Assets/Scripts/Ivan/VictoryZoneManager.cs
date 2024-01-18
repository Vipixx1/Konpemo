using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VictoryZoneManager : MonoBehaviour
{
    [SerializeField]
    KingManager kingManager;
    [SerializeField]
    TimeManager timeManager;
    [SerializeField]
    GameObject victoryScreen;
    [SerializeField]
    TMP_Text timeStamp;
    private string endTime;
    private void Start()
    {
        victoryScreen.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("ICI");
        if(kingManager.getKing() != null)
        {
            if (kingManager.getKing().gameObject.name == other.gameObject.name)
            {
                this.gameObject.SetActive(false);
                endTime = timeManager.GetTime();
                victoryScreen.SetActive(true);
                timeStamp.text = "Time: " + endTime;
            }
        }
    }
}
