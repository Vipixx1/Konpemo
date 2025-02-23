using System.Collections;
using UnityEngine;

public class Evoren : Konpemo
{
    [SerializeField] private GameObject buffEffect;

    private readonly float buffDuration = 10f;

    public override void SetBaseStats()
    {
        health.BaseValue = 500f;
        health.SetCurrentHealth(500f);
        strength.BaseValue = 40f;
        defense.BaseValue = 5f;
        speed.BaseValue = 7f;
        attackSpeed.BaseValue = 1f;

        cooldown.BaseValue = 15f;

        rangeAttack.BaseValue = 3f;
        rangeCapacity.BaseValue = 0f;
        rangeView.BaseValue = 10f;
    }

    public override void SetCapacityTypeAndName()
    {
        this.capacityType = CapacityType.NoClick;
        this.nameKonpemo = KonpemoSpecies.Evoren.ToString();
    }

    public override void Capacity(Vector3? localisation = null) // Gonflette
    {
        StartCoroutine(Gonflette());
    }

    public IEnumerator Gonflette()
    {
        buffEffect.SetActive(true);

        StatModifier gonfletteStrength = new(20f, StatModType.Flat);
        StatModifier gonfletteDefense = new(3f, StatModType.Flat);

        strength.AddModifier(gonfletteStrength);
        defense.AddModifier(gonfletteDefense);
        
        yield return new WaitForSeconds(buffDuration);
        
        buffEffect.SetActive(false);
        strength.RemoveModifier(gonfletteStrength);
        defense.RemoveModifier(gonfletteDefense);

    }
}
