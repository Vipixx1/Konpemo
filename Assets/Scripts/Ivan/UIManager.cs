using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Image redCursor;
    [SerializeField] Image blueCursor;

    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private GameObject victoryScreen;

    [SerializeField] private TMP_Text timer;

    [SerializeField] private TMP_Text konpemoLostCounter;

    private void Start()
    {
        redCursor.enabled = false;
        blueCursor.enabled = false;

        victoryScreen.SetActive(false);
        gameOverScreen.SetActive(false);
        timer.gameObject.SetActive(false);
    }

    void Update()
    {
        ShowTime();    
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
    public void DisplayDefeatScreen(int nbKonpemoLost)
    {
        gameOverScreen.SetActive(true);
        konpemoLostCounter.text = nbKonpemoLost + "fell...";
        ShowTime();
    }

    public void DisplayVictoryScreen()
    {
        victoryScreen.SetActive(true);
        ShowTime();
    }

    public void ShowTime()
    {
        int minutes = Mathf.FloorToInt(Time.time / 60F);
        int seconds = Mathf.FloorToInt(Time.time - minutes * 60);

        string niceTime = string.Format("{0:00}:{1:00}", minutes, seconds);
        timer.text = niceTime;
        timer.gameObject.SetActive(true);

    }

}
