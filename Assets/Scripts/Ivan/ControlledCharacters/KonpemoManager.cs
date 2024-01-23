using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KonpemoManager : MonoBehaviour
{
    private CharStateManager charStateManager;
    private Konpemo konpemo; //public ???
	
	public GameObject selectionEffect;
    [SerializeField]
    private AllyUnitManager allyUnitManager;
    [SerializeField]
    private EnemyUnitManager enemyUnitManager;
    [SerializeField]
    private string allyUnitMaskName = "Blue";
    [SerializeField]
    private string enemyUnitMaskName = "Red";
    private Konpemo allyUnitKonpemo;
    private Konpemo enemyUnitKonpemo;
    /*[SerializeField]
    private string health;*/
    private bool cdCapacityUp;
    private void Start()
    {
        //health = this.GetComponent<Konpemo>().health.Value.ToString();
        charStateManager = this.gameObject.GetComponent<CharStateManager>();
        konpemo = this.gameObject.GetComponentInParent<Konpemo>();

        cdCapacityUp = true;
        /*allyUnitManager = GameObject.Find("AllyUnitManager").GetComponent<AllyUnitManager>();
        enemyUnitManager = GameObject.Find("EnemyUnitManager").GetComponent<EnemyUnitManager>();
        if (this.gameObject.layer == LayerMask.NameToLayer(allyUnitMaskName))
        {
            allyUnitKonpemo = this.GetComponent<Konpemo>();
            allyUnitManager.allySpawn.Invoke(allyUnitKonpemo);
            StartCoroutine(IsAllyAliveCoroutine(allyUnitKonpemo));
        }
        if (this.gameObject.layer == LayerMask.NameToLayer(enemyUnitMaskName))
        {
            enemyUnitKonpemo = this.GetComponent<Konpemo>();
            enemyUnitManager.enemySpawn.Invoke(enemyUnitKonpemo);
            StartCoroutine(IsEnemyAliveCoroutine(enemyUnitKonpemo));
        }*/
    }

    public void AddMoveListener(EventManager eventManager)
    {
        eventManager.goToEvent.AddListener(MoveHandler);
        //Debug.Log("Listener bien ajouté");
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

            case CapacityType.ClickOnAlly:
                eventManager.capacityOnUnitEvent.AddListener(OnUnitCapacityHandler);
                break;

            case CapacityType.ClickOnEnemy:
                eventManager.capacityOnUnitEvent.AddListener(OnUnitCapacityHandler);
                break;

            default:
                //Debug.Log("Impossible d'attacher la capacité");
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

            case CapacityType.ClickOnAlly:
                eventManager.capacityOnUnitEvent.RemoveListener(OnUnitCapacityHandler);
                break;

            case CapacityType.ClickOnEnemy:
                eventManager.capacityOnUnitEvent.RemoveListener(OnUnitCapacityHandler);
                break;

            default:
                //Debug.Log("Impossible de retirer la capacité");
                break;
        }
    }

    public void NoClickCapacityHandler()
    {
        if (cdCapacityUp)
        {
            Debug.Log("R CAPACITY TO PUT HERE");
            konpemo.Capacity();
            StartCoroutine(CapacityCooldown(konpemo.cooldown.Value));
        }
    }
    public void OnGroundCapacityHandler(Vector3 localisationSpell)
    {
        if (cdCapacityUp)
        {
            Debug.Log("Z CAPACITY TO PUT HERE");
            konpemo.Capacity(localisationSpell);
            StartCoroutine(CapacityCooldown(konpemo.cooldown.Value));
        }
    }

    public void OnUnitCapacityHandler(GameObject targetToCastOn)
    {
        if (cdCapacityUp)
        {
            Debug.Log("E CAPACITY TO PUT HERE");
            //konpemo.Capacity(targetToCastOn);
            StartCoroutine(CapacityCooldown(konpemo.cooldown.Value));
        }
    }
    

    public void MoveHandler(Vector3 position)
    {
        //Debug.Log("J'ai reçu un goToEvent");
        charStateManager.destination = position;
        charStateManager.SwitchState(charStateManager.charMovingState);
    }

    public void AtkMoveHandler(Konpemo cible)
    {
        //Debug.Log("J'ai reçu un goToAtkEvent");
        charStateManager.cibleKonpemo = cible;
        charStateManager.SwitchState(charStateManager.charAtkMovState);
    }

    public void FlwAllyHandler(Konpemo allyToFollow)
    {
        charStateManager.cibleKonpemo = allyToFollow;
        charStateManager.SwitchState(charStateManager.charFlwAllyState);
    }

    private IEnumerator CapacityCooldown(float timeToWait)
    {
        cdCapacityUp = false;
        yield return new WaitForSeconds(timeToWait);
        cdCapacityUp = true;
    }
}