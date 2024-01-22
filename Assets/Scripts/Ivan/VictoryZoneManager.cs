using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VictoryZoneManager : MonoBehaviour
{
    [SerializeField] private KingManager kingManager;
    [SerializeField] private UIManager uiManager;

    private void OnTriggerEnter(Collider other)
    {
        if(kingManager.GetKing() != null)
        {
            if (kingManager.GetKing().gameObject.name == other.gameObject.name)
            {
                uiManager.DisplayVictoryScreen();
            }
        }
    }
}
