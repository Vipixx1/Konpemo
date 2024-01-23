using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Brouillard : MonoBehaviour
{
    [SerializeField] private LayerMask allyMask;
    [SerializeField] private EnemyUnitManager enemyUnitManager;

    private List<Konpemo> enemyKonpemos = new List<Konpemo>();
    private IAStateManager iaStateManager;
    private float fogTime = 5f;
    private void Start()
    {
        fogTime = 5f;
        enemyUnitManager = GameObject.Find("EnemyUnitManager").GetComponent<EnemyUnitManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (1 << other.gameObject.layer == allyMask.value)
        {
            enemyKonpemos = enemyUnitManager.GetEnemyKonpemos();
            foreach (Konpemo enemyKonpemo in enemyKonpemos)
            {
                if (iaStateManager = enemyKonpemo.GetComponentInChildren<IAStateManager>())
                {
                    StartCoroutine(FogCoroutine(iaStateManager, other.gameObject.GetComponent<Konpemo>()));
                }
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (1 << other.gameObject.layer == allyMask.value)
        {
            enemyKonpemos = enemyUnitManager.GetEnemyKonpemos();
            foreach (Konpemo enemyKonpemo in enemyKonpemos)
            {
                if (iaStateManager = enemyKonpemo.GetComponentInChildren<IAStateManager>())
                {
                    iaStateManager.invisbleKonpemos.Remove(other.gameObject.GetComponent<Konpemo>());
                }
            }
        }
    }
    public IEnumerator FogCoroutine(IAStateManager iAStateManager, Konpemo konpemo)
    {
        iAStateManager.invisbleKonpemos.Add(konpemo);
        yield return new WaitForSeconds(fogTime);
        if(iAStateManager.invisbleKonpemos.Contains(konpemo)) iAStateManager.invisbleKonpemos.Remove(konpemo);
        Destroy(gameObject);
    }
}
