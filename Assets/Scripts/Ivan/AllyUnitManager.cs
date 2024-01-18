using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class AllyUnitManager : MonoBehaviour
{
    public UnityEvent<Konpemo> allyDied;
    public UnityEvent<Konpemo> allySpawn;
    public List<Konpemo> aliveAllyKonpemos;

    [SerializeField]
    private UIManager uiManager;
    private int totalAllyUnitDied;
    void Start()
    {
        aliveAllyKonpemos = new List<Konpemo>();
        allyDied = new UnityEvent<Konpemo>();
        allySpawn = new UnityEvent<Konpemo>();
        allyDied.AddListener(AllyDiedHandler);
        allySpawn.AddListener(AllySpawnHandler);
        totalAllyUnitDied = 0;
        
    }
    private void Update()
    {
        CheckAllAllyDied();
    }
    public void AllyDiedHandler(Konpemo konpemo)
    {
        totalAllyUnitDied += 1;
        aliveAllyKonpemos.Remove(konpemo);
    }
    public void AllySpawnHandler(Konpemo konpemo)
    {
        aliveAllyKonpemos.Add(konpemo);
    }
    private void CheckAllAllyDied()
    {
        if (aliveAllyKonpemos.Count < 1)
        {
            uiManager.DisplayLoseScreen(totalAllyUnitDied);
        }
    }

    public int GetTotalAllyUnitDied()
    {
        return totalAllyUnitDied;
    }
}
