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
    public void EnemyDied(Konpemo konpemo)
    {
        aliveEnemyKonpemos.Remove(konpemo);
    }
    public void SetEnemyAlive(Konpemo konpemo)
    {
        aliveEnemyKonpemos.Add(konpemo);
    }
}
