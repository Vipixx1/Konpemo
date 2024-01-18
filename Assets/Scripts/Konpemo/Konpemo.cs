using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Konpemo : MonoBehaviour
{
    public Health health = new();
    public Strength strength = new();
    public Defense defense = new();
    public Speed speed = new();
    public AttackSpeed attackSpeed = new();
    public Cooldown cooldown = new();
    public RangeAttack rangeAttack = new();
    public RangeView rangeView = new();
    
    protected Konpemo konpemoEnemy = null;

    public bool isFlying = false;
    public bool isParalysed = false;
    public bool isPoisoned = false;

    [SerializeField]
    public int capacityType;
    [SerializeField]
    public AllyUnitManager allyUnitManager;
    [SerializeField]
    private string allyUnitMaskName = "Blue";
    public virtual void Start()
    {
        allyUnitManager = GameObject.Find("AllyUnitManager").GetComponent<AllyUnitManager>();
        SetBaseStats();
        if(this.gameObject.layer == LayerMask.NameToLayer(allyUnitMaskName))
        {
            allyUnitManager.allySpawn.Invoke(this);
            StartCoroutine(IsAliveCoroutine());
        }
    }
    public virtual IEnumerator IsAliveCoroutine()
    {
        while(true)
        {
            if (health.GetCurrentHealth() < 1)
            {
                Debug.Log("Je suis MORTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTT");
                allyUnitManager.allyDied.Invoke(this);
                this.Death();
                break;
            }
            yield return null;
        }
    }
    public abstract void SetBaseStats();

    public virtual void Attack()
    {

        konpemoEnemy?.TakingDamage(this.strength.Value);
    }

    public virtual void Capacity() 
    {
        Debug.Log("No capacity");

        //Pour les capacit�s qui ciblent une position ou un alli� pr�cis, rajouter :
        //Si appuie sur clique gauche { Action; SetCooldown(cdCapacity) }
        //Si appuie sur Echap ou clique droit { Annule;  pas de CD }
    }

    public virtual void Passive()
    {
        Debug.Log("No passive");
    }

    public virtual void TakingDamage(float rawDamage)
    {
        this.health.TakingFlatDamage(rawDamage, this.defense.Value);
    }

    public virtual void Healing(float healthHealed)
    {
        this.health.HealingFlatDamage(healthHealed);
    }
    public virtual void SetCooldown(float cooldown)
    {
        Debug.Log("Timer started" + cooldown);
    }
    public virtual void SetTarget(Konpemo target)
    {
        this.konpemoEnemy = target;
    }

    public virtual void Death()
    {
        this.gameObject.SetActive(false);
    }

    // Status of the Konpemo
    public virtual void Poisoning(float poisonTickDamage, int poisonDuration)
    {
        this.isPoisoned = true;
        StartCoroutine(Poison(poisonTickDamage, poisonDuration));
    }

    public virtual void Paralysing()
    {
        if (! isParalysed)
        {
            StartCoroutine(Paralyse());
        }
    }

    public virtual IEnumerator Poison(float poisonTickDamage, int poisonDuration)
    {
        int timer = 0;
        while (timer < poisonDuration)
        {
            this.health.TakingFlatDamage(poisonTickDamage, 0);
            /*if (this.currentHealth <= 0) { Death(); }*/
            timer++;
            yield return new WaitForSeconds(1);
        }
        if (timer >= poisonDuration) { isPoisoned = false; }
    }

    public virtual IEnumerator Paralyse()
    {
        {
            this.isParalysed = true;
            Debug.Log("bzz bzz");
            yield return new WaitForSeconds(1);
            this.isParalysed = false;
        }
    }
}