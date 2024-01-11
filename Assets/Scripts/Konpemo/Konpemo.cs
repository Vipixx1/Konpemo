using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using JetBrains.Annotations;
using UnityEngine;

public abstract class Konpemo : MonoBehaviour
{
    protected float currentHp;
    protected float baseHp;

    protected float currentDef;
    //protected float baseDef;

    protected float currentSpeed;
    //protected float baseSpeed;

    protected float currentDamage;
    //protected float baseDamage;

    protected float delayAtk;
    //protected float baseDelayAtk;

    protected float cooldown; //Time ?
    //protected float baseCooldown;

    protected Konpemo konpemoEnemy;

    public bool isFlying;
    public bool isSlewDown;
    public bool isParalysed;
    public bool isPoisoned;

    public Konpemo(float currentHp, float baseHp, float currentDef, /*float baseDef,*/ float currentSpeed, /*float baseSpeed,*/ float currentDamage, /*float baseDamage, */float delayAtk, float cooldown, bool isFlying)
    {
        this.currentHp = currentHp;
        this.baseHp = baseHp;

        this.currentDef = currentDef;
        //this.baseDef = baseDef;

        this.currentSpeed = currentSpeed;
        //this.baseSpeed = baseSpeed;

        this.currentDamage = currentDamage;
        //this.baseDamage = baseDamage;

        this.delayAtk = delayAtk;
        this.cooldown = cooldown;
        this.isFlying = isFlying;

        konpemoEnemy = null;
        isSlewDown = false;
        isParalysed = false;
        isPoisoned = false;
    }

    public virtual void Attack()
    {
        this.konpemoEnemy?.TakingDamage(this.currentDamage);
    }

    public virtual void Capacity() 
    {
        Debug.Log("No capacity");

        //Pour les capacités qui ciblent une position ou un allié précis, rajouter :
        //Si appuie sur clique gauche { Action; SetCooldown(cdCapacity) }
        //Si appuie sur Echap ou clique droit { Annule;  pas de CD }
    }

    public virtual void Passive()
    {
        Debug.Log("No passive");
    }

    public virtual void SetCooldown(float cooldown) /*Time cooldown ?*/
    {
        Debug.Log("Timer started" + cooldown);
    }

    public virtual void TakingDamage(float damageTaken)
    {
        this.currentHp -= Math.Max(1, damageTaken - this.currentDef);
        if (this.currentHp <= 0) { Death();  }
    }
    public virtual void SetTarget(Konpemo target)
    {
        this.konpemoEnemy = target;
    }

    public virtual void Healing(float hpHealed)
    {
        this.currentHp = Math.Min(this.baseHp, this.currentHp + hpHealed);
    }




    // Status of the Konpemo
    public virtual void SpeedDown(float speedDown)
    {
        this.currentSpeed = Math.Max(0.1f, this.currentSpeed - speedDown);
        this.isSlewDown = true;
    }

    public virtual void Poisoning()
    {
        this.isPoisoned = true;
        StartCoroutine(Poison());
    }

    public virtual void Paralysing()
    {
        if (! isParalysed)
        {
            StartCoroutine(Paralyse());
        }
    }

    public virtual void Death()
    {
        this.gameObject.SetActive(false);
    }

    public virtual IEnumerator Poison()
    {
        int timer = 0;
        while (timer < 10)
        {
            this.currentHp -= 10f;
            if (this.currentHp <= 0) { Death(); }
            timer++;
            yield return new WaitForSeconds(1);
        }
        if (timer >= 10) { isPoisoned = false; }
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