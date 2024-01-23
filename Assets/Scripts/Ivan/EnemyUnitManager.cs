using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class EnemyUnitManager : MonoBehaviour
{
    [SerializeField]
    private List<Konpemo> aliveEnemyKonpemos;

    [SerializeField]
    private UIManager uiManager;


    void Start()
    {
        aliveEnemyKonpemos = new List<Konpemo>();
    }

    private void Update()
    {
        uiManager.konpemoEnemyAliveCounter.text = GetEnemyAlive().ToString();
    }

    public void EnemyDied(Konpemo konpemo)
    {
        aliveEnemyKonpemos.Remove(konpemo);
    }
    public void SetEnemyAlive(Konpemo konpemo)
    {
        aliveEnemyKonpemos.Add(konpemo);
    }

    public int GetEnemyAlive()
    {
        return aliveEnemyKonpemos.Count;
    }

    public List<Konpemo> GetEnemyKonpemos()
    {
        return aliveEnemyKonpemos;
    }
}
