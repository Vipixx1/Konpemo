using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    Image redCursor;
    [SerializeField]
    Image blueCursor;
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
        redCursor.enabled = false;
        blueCursor.enabled = false;
        gameOverScreen.SetActive(false);
    }
    public void DisplaySpriteRed()
    {
        redCursor.enabled = true;
    }
    public void HideSpriteRed()
    {
        redCursor.enabled = false;
    }
    public void DisplaySpriteBlue()
    {
        blueCursor.enabled = true;
    }
    public void HideSpriteBlue()
    {
        blueCursor.enabled = false;
    }
    public void DisplayLoseScreen(int unitsLost)
    {
        endTime = timeManager.GetTime();
        gameOverScreen.SetActive(true);
        timeStampLose.text = "Time: " + endTime;
        unitLostCounter.text = unitsLost + " (units lost)";
    }

}
