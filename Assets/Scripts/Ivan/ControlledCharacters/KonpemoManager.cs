using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KonpemoManager : MonoBehaviour
{
    private CharStateManager charStateManager;
    private Konpemo konpemo;
	
	public GameObject selectionEffect;

    [SerializeField]
    private AllyUnitManager allyUnitManager;
    [SerializeField]
    private EnemyUnitManager enemyUnitManager;

    private bool cdCapacityUp;

    private void Start()
    {
        charStateManager = this.gameObject.GetComponent<CharStateManager>();
        konpemo = this.gameObject.GetComponentInParent<Konpemo>();

        cdCapacityUp = true;
    }

    public void AddMoveListener(EventManager eventManager)
    {
        eventManager.goToEvent.AddListener(MoveHandler);
        //Debug.Log("Listener bien ajoute");
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
    public void AddFlwAllyListener(EventManager eventManager)
    {
        eventManager.goToFlwAllyEvent.AddListener(FlwAllyHandler);
    }

    public void RemoveFlwAllyListener(EventManager eventManager)
    {
        eventManager.goToFlwAllyEvent.RemoveListener(FlwAllyHandler);
    }

    public void AddCapacityListener(EventManager eventManager)
    {
        switch (konpemo.capacityType)
        {
            case CapacityType.NoClick:
                eventManager.capacityNoClickEvent.AddListener(NoClickCapacityHandler);
                break;

            case CapacityType.ClickOnGround:
                eventManager.capacityOnGroundEvent.AddListener(OnGroundCapacityHandler);
                break;

            /*case CapacityType.ClickOnAlly:
                eventManager.capacityOnUnitEvent.AddListener(OnUnitCapacityHandler);
                break;

            case CapacityType.ClickOnEnemy:
                eventManager.capacityOnUnitEvent.AddListener(OnUnitCapacityHandler);
                break;*/

            default:
                //Debug.Log("Impossible d'attacher la capacite");
                break;
        }
    }
    public void RemoveCapacityListener(EventManager eventManager)
    {
        switch (konpemo.capacityType)
        {
            case CapacityType.NoClick:
                eventManager.capacityNoClickEvent.RemoveListener(NoClickCapacityHandler);
                break;

            case CapacityType.ClickOnGround:
                eventManager.capacityOnGroundEvent.RemoveListener(OnGroundCapacityHandler);
                break;

            /*case CapacityType.ClickOnAlly:
                eventManager.capacityOnUnitEvent.RemoveListener(OnUnitCapacityHandler);
                break;

            case CapacityType.ClickOnEnemy:
                eventManager.capacityOnUnitEvent.RemoveListener(OnUnitCapacityHandler);
                break;*/

            default:
                //Debug.Log("Impossible de retirer la capacite");
                break;
        }
    }

    public void NoClickCapacityHandler()
    {
        if (cdCapacityUp)
        {
            //Debug.Log("NO CLICK CAPACITY TO PUT HERE");
            konpemo.Capacity();
            StartCoroutine(CapacityCooldown(konpemo.cooldown.Value));
        }
    }
    public void OnGroundCapacityHandler(Vector3 localisationSpell)
    {
        if (cdCapacityUp)
        {
            //Debug.Log("ON GROUND CAPACITY TO PUT HERE");
            konpemo.Capacity(localisationSpell);
            StartCoroutine(CapacityCooldown(konpemo.cooldown.Value));
        }
    }

    /*public void OnUnitCapacityHandler()
    {
        if (cdCapacityUp)
        {
            Debug.Log("ON UNIT CAPACITY TO PUT HERE");
            konpemo.Capacity();
            StartCoroutine(CapacityCooldown(konpemo.cooldown.Value));
        }
    }*/
    

    public void MoveHandler(Vector3 position)
    {
        //Debug.Log("J'ai re�u un goToEvent");
        charStateManager.destination = position;
        charStateManager.SwitchState(charStateManager.charMovingState);
    }

    public void AtkMoveHandler(Konpemo target)
    {
        //Debug.Log("J'ai recu un goToAtkEvent");
        charStateManager.targetKonpemo = target;
        charStateManager.SwitchState(charStateManager.charAtkMovState);
    }

    public void FlwAllyHandler(Konpemo allyToFollow)
    {
        charStateManager.targetKonpemo = allyToFollow;
        charStateManager.SwitchState(charStateManager.charFlwAllyState);
    }

    private IEnumerator CapacityCooldown(float timeToWait)
    {
        cdCapacityUp = false;
        yield return new WaitForSeconds(timeToWait);
        cdCapacityUp = true;
    }
}