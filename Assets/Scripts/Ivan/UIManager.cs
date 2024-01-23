using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject redCursor;
    [SerializeField] private GameObject blueCursor;

    [SerializeField] private GameObject activeUI;
    [SerializeField] private TMP_Text timer;
    public TMP_Text konpemoEnemyAliveCounter;

    [SerializeField] private GameObject victoryScreen;
	[SerializeField] private TMP_Text victoryTimer;

    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private TMP_Text defeatTimer;
    [SerializeField] private TMP_Text konpemoAllyLostCounter;

    

    private void Start()
    {
        redCursor.SetActive(false);
        blueCursor.SetActive(false);
		
		victoryScreen.SetActive(false);
        gameOverScreen.SetActive(false);
		activeUI.SetActive(true);
        timer.gameObject.SetActive(true);
    }

    void Update()
    {
        timer.text = GetTime();    
        
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
	
    public void DisplayDefeatScreen(int nbKonpemoLost)
    {
        gameOverScreen.SetActive(true);
		defeatTimer.text = GetTime();
        konpemoAllyLostCounter.text = nbKonpemoLost + " fell...";
        activeUI.SetActive(false);
    }

    public void DisplayVictoryScreen()
    {
		victoryTimer.text = GetTime();
        victoryScreen.SetActive(true);
        activeUI.SetActive(false);
    }

    public string GetTime()
    {
        int minutes = Mathf.FloorToInt(Time.time / 60F);
        int seconds = Mathf.FloorToInt(Time.time - minutes * 60);

        string niceTime = string.Format("{0:00}:{1:00}", minutes, seconds);
        return niceTime;

    }

}
