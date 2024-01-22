using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    GameObject redCursor;
    [SerializeField]
    GameObject blueCursor;
    [SerializeField]
    private TimeManager timeManager;
    [SerializeField]
    private GameObject gameOverScreen;
    [SerializeField]
    private TMP_Text timeStampLose;
    [SerializeField]
    private TMP_Text unitLostCounter;

    private string endTime;

    private void Start()
    {
        redCursor.SetActive(false);
        blueCursor.SetActive(false);
        gameOverScreen.SetActive(false);
    }
    public void DisplaySpriteRed()
    {
        redCursor.SetActive(true);
    }
    public void HideSpriteRed()
    {
        redCursor.SetActive(false);
    }
    public void DisplaySpriteBlue()
    {
        blueCursor.SetActive(true);
    }
    public void HideSpriteBlue()
    {
        blueCursor.SetActive(false);
    }
    public void DisplayLoseScreen(int unitsLost)
    {
        endTime = timeManager.GetTime();
        gameOverScreen.SetActive(true);
        timeStampLose.text = "Time: " + endTime;
        unitLostCounter.text = unitsLost + " (units lost)";
    }

}
