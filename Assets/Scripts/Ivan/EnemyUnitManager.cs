using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class EnemyUnitManager : MonoBehaviour
{
    public UnityEvent<Konpemo> enemyDied;
    public UnityEvent<Konpemo> enemySpawn;
    public List<Konpemo> aliveEnemyKonpemos;

    void Start()
    {
        aliveEnemyKonpemos = new List<Konpemo>();
        enemyDied = new UnityEvent<Konpemo>();
        enemySpawn = new UnityEvent<Konpemo>();
        enemyDied.AddListener(EnemyDiedHandler);
        enemySpawn.AddListener(EnemySpawnHandler);

    }
    private void Update()
    {
        
    }
    public void EnemyDiedHandler(Konpemo konpemo)
    {
        aliveEnemyKonpemos.Remove(konpemo);
    }
    public void EnemySpawnHandler(Konpemo konpemo)
    {
        aliveEnemyKonpemos.Add(konpemo);
    }
}
