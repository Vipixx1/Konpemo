using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnRedManager : MonoBehaviour
{
    [SerializeField]
    private GameObject redManager;

    [SerializeField]
    private List<Spawner> spawnerRedList = new();

    [SerializeField] private Evoren evorenPrefab;
    [SerializeField] private Sourimi sourimiPrefab;
    [SerializeField] private Kairoche kairochePrefab;
    [SerializeField] private Serbiere serbierePrefab;
    [SerializeField] private Ninjax ninjaxPrefab;
    [SerializeField] private Caspow caspowPrefab;
    [SerializeField] private Beatowtron beatowtronPrefab;
    [SerializeField] private Caillebonbon caillebonbonPrefab;
    [SerializeField] private Magitruite magitruitePrefab;

    private readonly List<Konpemo> konpemos = new();

    void Start()
    {
        
        for (int i = 0; i < this.transform.childCount; i++)
        {
            Spawner tmp = this.transform.GetChild(i).GetComponent<Spawner>();
            spawnerRedList.Add(tmp);
        }

        GenerateRedTeam();

        for (int i = 0; i < Mathf.Min(spawnerRedList.Count, konpemos.Count); i++)
        {
            Spawner spawner = spawnerRedList[i];
            Konpemo konpemo = konpemos[i];

            spawner.SetKonpemo(konpemo);
            spawner.SetManager(redManager);
        }
    }


    private void GenerateRedTeam()
    {
        int nbKonpemoSpecies = Enum.GetValues(typeof(KonpemoSpecies)).Length;
        for (int i = 0;i < spawnerRedList.Count; i++)
        {
            System.Random rand = new();
            int konpemoId = rand.Next(0, nbKonpemoSpecies);
            Konpemo konpemo = ChooseKonpemo(konpemoId);

            konpemos.Add(konpemo);
        }
    
    }

    private Konpemo ChooseKonpemo(int konpemoId)
    {
        return konpemoId switch
        {
            0 => evorenPrefab,
            1 => sourimiPrefab,
            2 => kairochePrefab,
            3 => serbierePrefab,
            4 => ninjaxPrefab,
            5 => caspowPrefab,
            6 => beatowtronPrefab,
            7 => caillebonbonPrefab,
            8 => magitruitePrefab,
            _ => null,
        };
    }
}
