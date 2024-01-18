using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AllyUnitManager : MonoBehaviour
{
    public UnityEvent<Konpemo> allyDied;
    public UnityEvent<Konpemo> allySpawn;
    public   List<Konpemo> aliveAllyKonpemos;
    void Start()
    {
        aliveAllyKonpemos = new List<Konpemo>();
        allyDied = new UnityEvent<Konpemo>();
        allySpawn = new UnityEvent<Konpemo>();
        allyDied.AddListener(AllyDiedHandler);
        allySpawn.AddListener(AllySpawnHandler);
        
    }
    public void AllyDiedHandler(Konpemo konpemo)
    {
        aliveAllyKonpemos.Remove(konpemo);
    }
    public void AllySpawnHandler(Konpemo konpemo)
    {
        aliveAllyKonpemos.Add(konpemo);
    }
}
