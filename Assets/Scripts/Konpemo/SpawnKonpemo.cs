using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnKonpemo : MonoBehaviour
{
    private Transform spawnPoint;
    void Start()
    {
        
    }


    private void Spawning(Konpemo konpemo, Transform spawnPoint)
    {
        Konpemo newKonpemo = Instantiate(konpemo);
        newKonpemo.transform.position = spawnPoint.position;
        newKonpemo.transform.rotation = spawnPoint.rotation;
    }
}
