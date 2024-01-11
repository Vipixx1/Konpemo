using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagManager : MonoBehaviour
{
    [SerializeField]
    KingManager kingManager;
    [SerializeField]
    LayerMask masqueUniteAllie;
    LayerMask masquePreKing;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider preKing)
    {
        masquePreKing = 1 << preKing.gameObject.layer;
        if (masquePreKing == masqueUniteAllie)
        {
            Debug.Log("coucou");
            kingManager.setKing(preKing.gameObject);
            this.gameObject.SetActive(false);
            //Envois d'un kingAppearedEvent
        }
    }
}
