using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public abstract class Konpemo : MonoBehaviour
{
    public Health health = new();
    public Strength strength = new();
    public Defense defense = new();
    public Speed speed = new();
    public AttackSpeed attackSpeed = new();

    public Cooldown cooldown = new();

    public RangeAttack rangeAttack = new();
    public RangeCapacity rangeCapacity = new();
    public RangeView rangeView = new();
    
    protected Konpemo konpemoEnemy = null;

    public bool isParalysed = false;
    public bool isPoisoned = false;
	public bool canAttack;

    public CapacityType capacityType;
	
    [SerializeField] private AllyUnitManager allyUnitManager;
    [SerializeField] private EnemyUnitManager enemyUnitManager;

	protected NavMeshAgent agent;

    public Animator animator;

    public virtual void Start()
    {
		agent = this.gameObject.GetComponent<NavMeshAgent>();
        SetBaseStats();
		SetCapacityType();
        canAttack = true;
		
        /*allyUnitManager = GameObject.Find("AllyUnitManager").GetComponent<AllyUnitManager>();
        enemyUnitManager = GameObject.Find("EnemyUnitManager").GetComponent<EnemyUnitManager>();*/

        /*if(this.gameObject.layer == LayerMask.NameToLayer(allyUnitMaskName))
        {
            allyUnitManager.allySpawn.Invoke(this);
            StartCoroutine(IsAllyAliveCoroutine());
        }
        if (this.gameObject.layer == LayerMask.NameToLayer(enemyUnitMaskName))
        {
            enemyUnitManager.enemySpawn.Invoke(this);
            StartCoroutine(IsEnemyAliveCoroutine());
        }*/
    }

    public abstract void SetBaseStats();

    public virtual void SetCapacityType()
    {
        capacityType = CapacityType.NoCapacity;
    }
    public virtual IEnumerator IsAllyAliveCoroutine()
    {
        while(true)
        {
            if (health.GetCurrentHealth() < 1)
            {
                //Debug.Log("Je suis MORT");
                allyUnitManager.allyDied.Invoke(this);
                this.Death();
                break;
            }
            yield return null;
        }
    }
    public virtual IEnumerator IsEnemyAliveCoroutine()
    {
        while (true)
        {
            if (health.GetCurrentHealth() < 1)
            {
                //Debug.Log("Je suis MORT");
                enemyUnitManager.enemyDied.Invoke(this);
                this.Death();
                break;
            }
            yield return null;
        }
    }


    public virtual void Attack()
    {
        konpemoEnemy?.TakingDamage(this.strength.Value);
    }

    public virtual void Capacity(Vector3? localisation = null) 
    {
        Debug.Log("No capacity");
    }

    public virtual void Passive()
    {
        Debug.Log("No passive");
    }

    public virtual void TakingDamage(float rawDamage)
    {
        //animator.SetTrigger("TakingDamage");
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
        animator.SetTrigger("Death");
        //this.gameObject.SetActive(false);
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

public enum KonpemoSpecies
{
    Evoren,
    Sourimi,
    Kairoche,
    Serbiere,
    Ninjax,
    Caspow,
    Beatowtron,
    Caillebonbon,
    Magitruite,
}

public enum CapacityType
{
    NoCapacity,     // 0. Don't do anything when launch capacity
    NoClick,        // 1. No need to click anywhere to launch capacity
    ClickOnGround,  // 2. Need to click on the ground to launch capacity
    ClickOnAlly,    // 3. Need to click on an ally to launch capacity
    ClickOnEnemy,   // 4. Need to click on an enemy to launch capacity
}