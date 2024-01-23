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


    [SerializeField] private TMP_Text textSelection1;
    [SerializeField] private Slider healthBar1;
    [SerializeField] private TMP_Text textSelection2;
    [SerializeField] private Slider healthBar2;
    [SerializeField] private TMP_Text textSelection3;
    [SerializeField] private Slider healthBar3;
    [SerializeField] private TMP_Text textSelection4;
    [SerializeField] private Slider healthBar4;
    [SerializeField] private TMP_Text textSelection5;
    [SerializeField] private Slider healthBar5;

    private List<Slider> sliderList = new();
    private List<TMP_Text> textList = new();



    private void Start()
    {
        redCursor.SetActive(false);
        blueCursor.SetActive(false);
		
		victoryScreen.SetActive(false);
        gameOverScreen.SetActive(false);
		activeUI.SetActive(true);
        timer.gameObject.SetActive(true);

        SetupListHealthBar(sliderList);
        SetupListText(textList);

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
    public void SetupListText(List<TMP_Text> textList)
    {
        textList.Add(textSelection1);
        textList.Add(textSelection2);
        textList.Add(textSelection3);
        textList.Add(textSelection4);
        textList.Add(textSelection5);
    }
    public void SetupListHealthBar(List<Slider> sliderList)
    {
        sliderList.Add(healthBar1);
        sliderList.Add(healthBar2);
        sliderList.Add(healthBar3);
        sliderList.Add(healthBar4);
        sliderList.Add(healthBar5);
    }
    public void EditKonpemosPresentStart(List<Konpemo> konpemos)
    {
        int i = 0;
        foreach(Konpemo konpemo in konpemos)
        {
            textList[i].text = konpemos[i].nameKonpemo;
            sliderList[i].maxValue = konpemos[i].health.BaseValue;
            sliderList[i].value = konpemos[i].health.Value;
            i++;
        }
    }
    public void EditKonpemosPresent(List<Konpemo> konpemos)
    {
        int i = 0;
        foreach (Konpemo konpemo in konpemos)
        {
            textList[i].text = konpemos[i].nameKonpemo;
            sliderList[i].maxValue = konpemos[i].health.Value;
            sliderList[i].value = konpemos[i].health.GetCurrentHealth();
            i++;
        }
    }

}
