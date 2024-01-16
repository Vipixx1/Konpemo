using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KonpemoManager : MonoBehaviour
{
    public CharStateManager charStateManager;

    private void Start()
    {
        charStateManager = this.gameObject.GetComponent<CharStateManager>();
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

    public void AddNormalCapListener()
    {
        
    }
    public void RemoveNormalCapListener()
    {

    }

    public void AddCibleTerrainCapListener()
    {

    }

    public void RemoveCibleTerrainCapListener()
    {

    }

    public void AddCibleUnitCapListener()
    {

    }

    public void RemoveCibleUnitCapListenr()
    {

    }

    public void MoveHandler(Vector3 position)
    {
        Debug.Log("J'ai reçu un goToEvent");
        charStateManager.destination = position;
        charStateManager.SwitchState(charStateManager.charMovingState);
    }

    public void AtkMoveHandler(GameObject cible)
    {
        Debug.Log("J'ai reçu un goToAtkEvent");
        charStateManager.cibleKonpemo = cible;
        charStateManager.SwitchState(charStateManager.charAtkMovState);
    }
}