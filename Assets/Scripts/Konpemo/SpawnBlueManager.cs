using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnBlueManager : MonoBehaviour
{
    [SerializeField]
    private GameObject blueManager;

    [SerializeField]
    private List<Transform> spawnerBlueList = new();

    private readonly List<Konpemo> konpemos = KonpemoCounting.konpemosBlue;

    private AllyUnitManager allyUnitManager;

    void Start()
    {

        allyUnitManager = GameObject.Find("AllyUnitManager").GetComponent<AllyUnitManager>();

        for (int i = 0; i < this.transform.childCount; i++)
        {
            Transform tmp = this.transform.GetChild(i).GetComponent<Transform>();
            spawnerBlueList.Add(tmp);
        }

        for (int j = 0; j < Mathf.Min(spawnerBlueList.Count, konpemos.Count); j++)
        {
            Transform spawnerPosition = spawnerBlueList[j];
            Konpemo konpemoPrefab = konpemos[j];

            Konpemo newKonpemo = Instantiate(konpemoPrefab);
            newKonpemo.gameObject.layer = this.gameObject.layer;

            GameObject newManager = Instantiate(blueManager);
            newManager.transform.parent = newKonpemo.transform;

            newKonpemo.transform.SetPositionAndRotation(spawnerPosition.position, spawnerPosition.rotation);
            
            spawnerPosition.gameObject.SetActive(false);

            allyUnitManager.SetAllyAlive(newKonpemo);

            newKonpemo.onDeath.AddListener(Handler);
        }

    }
    public void Handler(Konpemo konpemo)
    {
        allyUnitManager.AllyDied(konpemo);
    }

}
