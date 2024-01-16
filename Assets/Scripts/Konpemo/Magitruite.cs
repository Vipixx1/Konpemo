using System.Collections;
using UnityEngine;
using System;
using System.Linq;
using UnityEngine.UI;


public class Magitruite : Konpemo
{
    private float speedDown = 1f;

    public override void SetBaseStats()
    {
        health.BaseValue = 10f;
        health.SetCurrentHealth(10f);
        strength.BaseValue = 0f;
        defense.BaseValue = 0f;
        speed.BaseValue = 0.5f;
        attackSpeed.BaseValue = 0.5f;
        cooldown.BaseValue = 0f;
        rangeAttack.BaseValue = 1f;
        rangeView.BaseValue = 5f;
    }

    public override void Attack() // Gouttelette
    {
        Collider[] hitColliders = Physics.OverlapSphere(this.transform.position, 4f, 6);

        foreach (Collider collider in hitColliders.Where(collider => collider.gameObject.layer != this.gameObject.layer))
        {
            if (collider.GetComponent<Konpemo>().speed.StatModifiers != null)
            {
                bool isHitByGouttelette = false;
                foreach (StatModifier speedMod in collider.GetComponent<Konpemo>().speed.StatModifiers)
                {
                    if (speedMod.Source.ToString() == "Gouttelette") { isHitByGouttelette = true; }
                }

                if (! isHitByGouttelette)
                {
                    StartCoroutine(Gouttelette(collider.GetComponent<Konpemo>()));
                }
            }
        }
    }

    public IEnumerator Gouttelette(Konpemo konpemo)
    {
        konpemo.speed.AddModifier(new StatModifier(-0.1f, StatModType.PercentMult, "Gouttelette"));
        yield return new WaitForSeconds(5);
        konpemo.speed.RemoveAllModifiersFromSource("Gouttelette");

    }
    public override void Passive()
    {
        Debug.Log("Pluie magique");
    }

    public override void TakingDamage(float damageTaken) //2e passif !
    {
        System.Random rand = new System.Random();
        this.health.TakingFlatDamage(rand.Next(0, 2), 0);
    }

    public override void Healing(float hpHealed)
    {
        System.Random rand = new System.Random();
        this.health.HealingFlatDamage(rand.Next(0, 2));
    }

    public override IEnumerator Poison(float poisonTickDamage, int poisonDuration)
    {
        int timer = 0;
        while (timer < poisonDuration)
        {
            System.Random rand = new System.Random();
            this.health.TakingFlatDamage(rand.Next(0, 2), 0);
            // if (this.health.currentHealth <= 0) { Death(); }
            timer++;
            yield return new WaitForSeconds(1);
        }
        if (timer >= poisonDuration) { isPoisoned  = false; }
    }
}
