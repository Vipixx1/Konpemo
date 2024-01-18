using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KingManager : MonoBehaviour
{
    [SerializeField]
    private Konpemo theKing;
    [SerializeField]
    private UIManager uiManager;
    [SerializeField]
    private AllyUnitManager allyUnitManager;

    private void Start()
    {

    }
    public void setKing(Konpemo gameObjectKing)
    {
        if (theKing == null)
        {
            theKing = gameObjectKing;
            StartCoroutine(IsKingAliveCoroutine());
        }
    }

    public Konpemo getKing()
    {
        return theKing;
    }

    private IEnumerator IsKingAliveCoroutine()
    {
        while (true)
        {
            if (theKing.health.GetCurrentHealth() < 1)
            {
                uiManager.DisplayLoseScreen(allyUnitManager.GetTotalAllyUnitDied());
                break;
            }
            yield return null;
        }
        yield return null;
    }
    //besoin de mettre un trigger pour la condition de victoire
}