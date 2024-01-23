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
    private List<Transform> spawnerRedList = new();

    [SerializeField] private Evoren evorenPrefab;
    [SerializeField] private Sourimi sourimiPrefab;
    [SerializeField] private Kairoche kairochePrefab;
    [SerializeField] private Serbiere serbierePrefab;
    [SerializeField] private Ninjax ninjaxPrefab;
    [SerializeField] private Caspow caspowPrefab;
    [SerializeField] private Beatowtron beatowtronPrefab;
    [SerializeField] private Caillebonbon caillebonbonPrefab;
    [SerializeField] private Magitruite magitruitePrefab;

    public static List<Konpemo> konpemosRed = new();

    private EnemyUnitManager enemyUnitManager;

    void Start()
    {
        enemyUnitManager = GameObject.Find("EnemyUnitManager").GetComponent<EnemyUnitManager>();

        for (int i = 0; i < this.transform.childCount; i++)
        {
            Transform tmp = this.transform.GetChild(i).GetComponent<Transform>();
            spawnerRedList.Add(tmp);
        }

        GenerateRedTeam();

        for (int j = 0; j < Mathf.Min(spawnerRedList.Count, konpemosRed.Count); j++)
        {
            Transform spawnerPosition = spawnerRedList[j];
            Konpemo konpemoPrefab = konpemosRed[j];

            Konpemo newKonpemo = Instantiate(konpemoPrefab);
            newKonpemo.gameObject.layer = this.gameObject.layer;

            GameObject newManager = Instantiate(redManager);
            newManager.transform.parent = newKonpemo.transform;

            newKonpemo.transform.SetPositionAndRotation(spawnerPosition.position, spawnerPosition.rotation);

            spawnerPosition.gameObject.SetActive(false);

            enemyUnitManager.SetEnemyAlive(newKonpemo);

            newKonpemo.onDeath.AddListener(Handler);
        }
    }
    public void Handler(Konpemo konpemo)
    {
        enemyUnitManager.EnemyDied(konpemo);
    }


    private void GenerateRedTeam()
    {
        int nbKonpemoSpecies = Enum.GetValues(typeof(KonpemoSpecies)).Length;
        for (int i = 0;i < spawnerRedList.Count; i++)
        {
            System.Random rand = new();
            int konpemoId = rand.Next(0, nbKonpemoSpecies);
            Konpemo konpemo = ChooseKonpemo(konpemoId);

            konpemosRed.Add(konpemo);
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
