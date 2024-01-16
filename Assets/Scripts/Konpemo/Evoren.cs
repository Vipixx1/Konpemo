using System.Collections;
using UnityEngine;

public class Evoren : Konpemo
{
    public override void SetBaseStats()
    {
        health.BaseValue = 500f;
        health.SetCurrentHealth(500f);
        strength.BaseValue = 40f;
        defense.BaseValue = 5f;
        speed.BaseValue = 5f;
        attackSpeed.BaseValue = 1f;
        cooldown.BaseValue = 15f;
        rangeAttack.BaseValue = 5f;
        rangeView.BaseValue = 15f;
    }

    public override void Capacity() // Gonflette
    {
        StartCoroutine(Gonflette());
        SetCooldown(cooldown.Value);
    }

    public IEnumerator Gonflette()
    {
        StatModifier gonfletteStrength = new(20f, StatModType.Flat);
        StatModifier gonfletteDefense = new(3f, StatModType.Flat);

        strength.AddModifier(gonfletteStrength);
        defense.AddModifier(gonfletteDefense);
        
        yield return new WaitForSeconds(10);
        
        strength.RemoveModifier(gonfletteStrength);
        defense.RemoveModifier(gonfletteDefense);

    }
    /*private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("Evoren HP: " + health.Value);
            Debug.Log("Evoren ATK: " + strength.Value);
            Debug.Log("Evoren DEF: " + defense.Value);
        }
    }*/
}
