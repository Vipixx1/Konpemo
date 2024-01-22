using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagManager : MonoBehaviour
{
    [SerializeField] private KingManager kingManager;

    [SerializeField] private LayerMask masqueUniteAllie;
    
    private LayerMask masquePreKing;


    private void OnTriggerEnter(Collider preKing)
    {
        masquePreKing = 1 << preKing.gameObject.layer;
        if (masquePreKing == masqueUniteAllie)
        {
            kingManager.SetKing(preKing.gameObject.GetComponent<Konpemo>());
            this.gameObject.SetActive(false);
        }
    }
}
