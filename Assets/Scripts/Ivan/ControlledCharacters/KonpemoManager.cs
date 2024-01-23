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
                eventManager.rCapacityEvent.AddListener(RCapacityHandler);
                break;

            case CapacityType.ClickOnGround:
                eventManager.zCapacityEvent.AddListener(ZCapacityHandler);
                break;

            case CapacityType.ClickOnAlly:
                eventManager.eCapacityEvent.AddListener(ECapacityHandler);
                break;

            case CapacityType.ClickOnEnemy:
                eventManager.eCapacityEvent.AddListener(ECapacityHandler);
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
                eventManager.rCapacityEvent.RemoveListener(RCapacityHandler);
                break;

            case CapacityType.ClickOnGround:
                eventManager.zCapacityEvent.RemoveListener(ZCapacityHandler);
                break;

            case CapacityType.ClickOnAlly:
                eventManager.eCapacityEvent.RemoveListener(ECapacityHandler);
                break;

            case CapacityType.ClickOnEnemy:
                eventManager.eCapacityEvent.RemoveListener(ECapacityHandler);
                break;

            default:
                //Debug.Log("Impossible de retirer la capacité");
                break;
        }
    }

    public void RCapacityHandler()
    {
        if (cdCapacityUp)
        {
            Debug.Log("R CAPACITY TO PUT HERE");
            konpemo.Capacity();
            StartCoroutine(CapacityCooldown(konpemo.cooldown.Value));
        }
    }
    public void ECapacityHandler(GameObject cibleToCastOn)
    {
        if (cdCapacityUp)
        {
            Debug.Log("E CAPACITY TO PUT HERE");
            //konpemo.Capacity(cibleToCastOn);
            StartCoroutine(CapacityCooldown(konpemo.cooldown.Value));
        }
    }
    public void ZCapacityHandler(Vector3 localisationSpell)
    {
        if (cdCapacityUp)
        {
            Debug.Log("Z CAPACITY TO PUT HERE");
            konpemo.Capacity(localisationSpell);
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
    public virtual IEnumerator IsAllyAliveCoroutine(Konpemo konpemo)
    {
        while (true)
        {
            if (konpemo.health.GetCurrentHealth() < 1)
            {
                //Debug.Log("Je suis MORTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTT");
                allyUnitManager.allyDied.Invoke(konpemo);
                konpemo.Death();
                break;
            }
            yield return null;
        }
    }
    public virtual IEnumerator IsEnemyAliveCoroutine(Konpemo konpemo)
    {
        while (true)
        {
            if (konpemo.health.GetCurrentHealth() < 1)
            {
                //Debug.Log("Je suis MORTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTT");
                enemyUnitManager.enemyDied.Invoke(konpemo);
                konpemo.Death();
                break;
            }
            yield return null;
        }
    }
}