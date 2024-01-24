using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;


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

    public bool isPoisoned;
	public bool canAttack;

    public CapacityType capacityType;
	
    public string nameKonpemo;
	
    [SerializeField] private AllyUnitManager allyUnitManager;
    [SerializeField] protected EnemyUnitManager enemyUnitManager;

    protected NavMeshAgent agent;

    public Animator animator;

    public GameObject capacityArea;

    public UnityEvent<Konpemo> onDeath;

    //==================================================//
    public virtual void Start()
    {
        SetBaseStats();
		SetCapacityTypeAndName();
        isPoisoned = false;
        canAttack = true;

        agent = this.gameObject.GetComponent<NavMeshAgent>();

        // Define the circle that show the range of the CapacitySpell
        capacityArea.transform.localScale = new Vector3(rangeCapacity.Value, 0, rangeCapacity.Value)*2;
        capacityArea.SetActive(false);

        // Define the Health for the animator, to transit ultimately to the 'Death' animation
        // this.animator.SetFloat("Health", health.Value);
    }

    //==================================================//
    public abstract void SetBaseStats();

    public virtual void SetCapacityTypeAndName()
    {
        capacityType = CapacityType.NoCapacity;
    }

    // The Konpemo can launch a basic attack
    public virtual void Attack()
    {
        konpemoEnemy?.TakingDamage(this.strength.Value);
    }

    // The Konpemo can launch a Capacity spell (TP, Flash, Traps, etc.)
    public virtual void Capacity(Vector3? localisation = null)
    {
        Debug.Log("No capacity");
    }

    // The Konpemo can have a passive sometimes
    public virtual void Passive()
    {
        Debug.Log("No passive");
    }

    //==================================================//
    public virtual void TakingDamage(float rawDamage)
    {
        this.health.TakingFlatDamage(rawDamage, this.defense.Value);

        if (this.health.GetCurrentHealth() < 0) { Death(); }

        // Death animation doesn't work properly : Because multiple Death() functions exist. So no animation for DEATH YET...
        // this.animator.SetFloat("Health", this.health.GetCurrentHealth());
    }

    public virtual void Healing(float healthHealed)
    {
        Debug.Log("Healed");
        this.health.HealingFlatDamage(healthHealed);
    }

    public virtual void SetTarget(Konpemo target)
    {
        this.konpemoEnemy = target;
    }

    public virtual void Death()
    {
        onDeath.Invoke(this);
        this.gameObject.SetActive(false);
        /*Add eventually Object Pools...*/

    }

    //==================================================//
    public virtual void Poisoning(float poisonTickDamage, int poisonDuration)
    {
        this.isPoisoned = true;
        StartCoroutine(Poison(poisonTickDamage, poisonDuration));
    }

    public virtual IEnumerator Poison(float poisonTickDamage, int poisonDuration)
    {
        int timer = 0;
        while (timer < poisonDuration)
        {
            this.health.TakingFlatDamage(poisonTickDamage, 0);
            timer++;
            yield return new WaitForSeconds(1);
        }
        if (timer >= poisonDuration) { isPoisoned = false; }
    }

    //================GODMOD FOR THE TESTS====================//
    public void Update()
    {
        // Kill all the allies : Press [P]
        if(Input.GetKeyDown(KeyCode.P))
        {
            if(this.gameObject.layer == 7)
            {
                this.TakingDamage(50);
            }
        }

        // Kill all the enemies : Press [M]
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (this.gameObject.layer == 8)
            {
                this.TakingDamage(50);
            }
        }

        // Heal all the allies : Press [I]
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (this.gameObject.layer == 7)
            {
                this.Healing(50);
            }
        }
    }

}

public enum KonpemoSpecies
{
    Evoren,         // 0. Base Unit (self boost)
    Sourimi,        // 1. Single Target Mage (TP/Flash)
    Kairoche,       // 2. Tank Unit (Taunt + Self-Destruct)
    Serbiere,       // 3. AoE Mage (Put traps)
    Ninjax,         // 4. Ninja Unit (SmokeScreen)
    Caspow,         // 5. Thieve Unit (Poison AOE)
    Beatowtron,     // 6. Heal Unit (AOE HEAL RNG)
    Caillebonbon,   // 7. Flying Unit (Can't really fly yet)
    Magitruite,     // 8. Jester (Debuff + Tank RNG)
}

public enum CapacityType
{
    NoCapacity,         // 0. Don't do anything when launch capacity
    NoClick,            // 1. No need to click anywhere to launch capacity
    ClickOnGround,      // 2. Need to click on the ground to launch capacity

    //NO TIME TO CREATE THOSE KIND OF CAPACITIES
    //ClickOnAlly,      // 3. Need to click on an ally to launch capacity
    //ClickOnEnemy,     // 4. Need to click on an enemy to launch capacity
}

