using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnBlueManager : MonoBehaviour
{
    [SerializeField]
    private GameObject blueManager;

    [SerializeField]
    private List<Spawner> spawnerBlueList = new();

    private readonly List<Konpemo> konpemos = KonpemoCounting.konpemosBlue;

    void Start()
    {
        for (int i = 0; i < this.transform.childCount; i++)
        {
            Spawner tmp = this.transform.GetChild(i).GetComponent<Spawner>();
            spawnerBlueList.Add(tmp);
        }

        for (int j = 0; j < Mathf.Min(spawnerBlueList.Count, konpemos.Count); j++)
        {
            Spawner spawner = spawnerBlueList[j];
            Konpemo konpemo = konpemos[j];

            spawner.SetKonpemo(konpemo);
            spawner.SetManager(blueManager);
        }
        
    }

}
