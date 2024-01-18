using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KingManager : MonoBehaviour
{
    [SerializeField] 
    private GameObject gameOverScreen;
    [SerializeField]
    private TMP_Text timeStamp;
    [SerializeField]
    private TMP_Text unitLostCounter;
    [SerializeField]
    private TimeManager timeManager;
    [SerializeField]
    private Konpemo theKing;
    private int mUnitLostCounter;
    private string endTime;

    private void Start()
    {
        gameOverScreen.SetActive(false);
    }
    public void setKing(Konpemo gameObjectKing)
    {
        if (theKing == null)
        {
            theKing = gameObjectKing;
            StartCoroutine(IsKingAliveCoroutine());
        }
    }

    public Konpemo getKing()
    {
        return theKing;
    }

    private IEnumerator IsKingAliveCoroutine()
    {
        while (true)
        {
            if (theKing.health.GetCurrentHealth() < 1)
            {
                endTime = timeManager.GetTime();
                gameOverScreen.SetActive(true);
                timeStamp.text = "Time: "+endTime;
                unitLostCounter.text = "10 (units lost)";
                break;
            }
            yield return null;
        }
        yield return null;
    }
    //besoin de mettre un trigger pour la condition de victoire
    public void UnitDied()
    {
        mUnitLostCounter += 1;
    }
}