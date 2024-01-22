using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KingManager : MonoBehaviour
{
    [SerializeField] private Konpemo king;

    [SerializeField] private UIManager uiManager;
    [SerializeField] private AllyUnitManager allyUnitManager;


    public Konpemo GetKing() { return king; }

    public void SetKing(Konpemo gameObjectKing)
    {
        if (king == null)
        {
            king = gameObjectKing;
            StartCoroutine(IsKingAliveCoroutine());
        }
    }

    private IEnumerator IsKingAliveCoroutine()
    {
        while (true)
        {
            if (king.health.GetCurrentHealth() <= 0)
            {
                uiManager.DisplayDefeatScreen(allyUnitManager.GetTotalAllyUnitDied());
                break;
            }
            yield return null;
        }
        yield return null;
    }

    //Besoin de mettre un trigger pour la condition de victoire
}