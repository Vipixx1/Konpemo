using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class AllyUnitManager : MonoBehaviour
{
    [SerializeField]
    private List<Konpemo> aliveAllyKonpemos;
    [SerializeField] private UIManager uiManager;
    private int totalAllyUnitDied;
    private bool isEveryoneDead = false;

    void Start()
    {
        aliveAllyKonpemos = new();
        totalAllyUnitDied = 0;
        isEveryoneDead = false;  
    }
    private void Update()
    {
        CheckAllAllyDied();
    }

    public void AllyDied(Konpemo konpemo)
    {
        //Debug.Log(aliveAllyKonpemos.Remove(konpemo));
        aliveAllyKonpemos.Remove(konpemo);
        totalAllyUnitDied += 1;   
    }

    public void SetAllyAlive(Konpemo konpemo)
    {
        aliveAllyKonpemos.Add(konpemo);
    }

    private void CheckAllAllyDied()
    {
        if (aliveAllyKonpemos.Count < 1 && !isEveryoneDead)
        {
			isEveryoneDead = true;
            uiManager.DisplayDefeatScreen(GetTotalAllyUnitDied());

        }
    }

    public int GetTotalAllyUnitDied()
    {
        return totalAllyUnitDied;
    }
}
