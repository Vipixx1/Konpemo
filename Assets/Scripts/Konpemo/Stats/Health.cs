using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Health : CharacterStat
{
    private float currentHealth;
    public void SetCurrentHealth(float currentHealth)
    {
        this.currentHealth = currentHealth;
    }

    public float GetCurrentHealth()
    {
        return this.currentHealth;
    }

    public void TakingFlatDamage(float rawDamage, float defense)
    {
        this.currentHealth -= Math.Max(1, rawDamage - defense);
    }

    public void HealingFlatDamage(float healValue)
    {
        this.currentHealth = Math.Min(this.BaseValue, this.currentHealth + healValue);
    }
    public void GetHealthDebug()
    {
        Debug.Log(this.currentHealth);
    }
}
