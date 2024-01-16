using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KonpemoManager : MonoBehaviour
{
    public CharStateManager charStateManager;
    public Konpemo konpemo;
    private void Start()
    {
        charStateManager = this.gameObject.GetComponent<CharStateManager>();
        konpemo = this.gameObject.GetComponent<Konpemo>();
    }
    public void AddMoveListener(EventManager eventManager)
    {
        eventManager.goToEvent.AddListener(MoveHandler);
        Debug.Log("Listener bien ajouté");
    }

    public void RemoveMoveListener(EventManager eventManager)
    {
        eventManager.goToEvent.RemoveListener(MoveHandler);
    }

    public void AddAtkMoveListener(EventManager eventManager)
    {
        eventManager.goToAtkEvent.AddListener(AtkMoveHandler);
    }

    public void RemoveAtkMoveListener(EventManager eventManager)
    {
        eventManager.goToAtkEvent.RemoveListener(AtkMoveHandler);
    }
    public void AddCapacityListener(EventManager eventManager)
    {
        switch (konpemo.capacityType)
        {
            case 1:
                eventManager.rCapacityEvent.AddListener(RCapacityHandler);
                break;
            case 2:
                eventManager.eCapacityEvent.AddListener(ECapacityHandler);
                break;
            case 3:
                eventManager.zCapacityEvent.AddListener(ZCapacityHandler);
                break;
            default:
                Debug.Log("Impossible d'attacher la capacité");
                break;
        }
    }
    public void RemoveCapacityListener(EventManager eventManager)
    {
        switch (konpemo.capacityType)
        {
            case 1:
                eventManager.rCapacityEvent.RemoveListener(RCapacityHandler);
                break;
            case 2:
                eventManager.eCapacityEvent.RemoveListener(ECapacityHandler);
                break;
            case 3:
                eventManager.zCapacityEvent.RemoveListener(ZCapacityHandler);
                break;
            default:
                Debug.Log("Impossible d'attacher la capacité");
                break;
        }
    }

    public void RCapacityHandler()
    {
        Debug.Log("R CAPACITY TO PUT HERE");
        konpemo.Capacity();
    }
    public void ECapacityHandler(GameObject cibleToCastOn)
    {
        Debug.Log("E CAPACITY TO PUT HERE");
        //konpemo.Capacity(cibleToCastOn);
    }
    public void ZCapacityHandler(Vector3 localisationSpell)
    {
        Debug.Log("Z CAPACITY TO PUT HERE");
        //konpemo.Capacity(localisationSpell);
    }

    public void MoveHandler(Vector3 position)
    {
        Debug.Log("J'ai reçu un goToEvent");
        charStateManager.destination = position;
        charStateManager.SwitchState(charStateManager.charMovingState);
    }

    public void AtkMoveHandler(Konpemo cible)
    {
        Debug.Log("J'ai reçu un goToAtkEvent");
        charStateManager.cibleKonpemo = cible;
        charStateManager.SwitchState(charStateManager.charAtkMovState);
    }
}