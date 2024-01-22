using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private Konpemo konpemo;

    private GameObject teamManager;

    private Transform spawnPoint;
    private LayerMask team;

    void Start()
    {
        team = this.gameObject.layer;
        spawnPoint = this.transform;
        if (konpemo != null) Spawning();
    }

    private void Spawning()
    {
        Konpemo newKonpemo = Instantiate(konpemo);
        GameObject newManager = Instantiate(teamManager);
        newManager.transform.parent = newKonpemo.transform;
        
        newKonpemo.transform.SetPositionAndRotation(spawnPoint.position, spawnPoint.rotation);
        newKonpemo.gameObject.layer = team;
        this.gameObject.SetActive(false);
    }

    public void SetKonpemo(Konpemo konpemo)
    {
        this.konpemo = konpemo;
    }

    public void SetManager(GameObject manager)
    {
        this.teamManager = manager;
    }
}
