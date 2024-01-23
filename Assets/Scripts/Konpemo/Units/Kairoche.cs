using UnityEngine;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using Unity.VisualScripting;

public class Kairoche : Konpemo
{

    private IAStateManager iaStateManager;

    public override void SetBaseStats()
    {
        health.BaseValue = 650f;
        health.SetCurrentHealth(650f);
        strength.BaseValue = 30f;
        defense.BaseValue = 10f;
        speed.BaseValue = 3f;
        attackSpeed.BaseValue = 1f;

        cooldown.BaseValue = 15f;

        rangeAttack.BaseValue = 3f;
        rangeCapacity.BaseValue = 6f;
        rangeView.BaseValue = 10f;
    }
    public override void SetCapacityTypeAndName()
    {
        this.capacityType = CapacityType.NoClick;
        this.nameKonpemo = KonpemoSpecies.Kairoche.ToString();
    }

    public override void Capacity(Vector3? localisation = null) // Taunt
    {
        Collider[] hitColliders = Physics.OverlapSphere(this.transform.position, rangeCapacity.Value);
        foreach (Collider collider in hitColliders) if (collider.GetComponent<Konpemo>() != null)
        {
            //Ne Marche que pour les allies :
            if(iaStateManager = collider.GetComponent<IAStateManager>())
            {
                StartCoroutine(tauntCoroutine(iaStateManager));
            }
        }
    }
    public IEnumerator tauntCoroutine(IAStateManager mIaStateManager)
    {
        mIaStateManager.taunterKonpemos.Add(this);
        yield return new WaitForSeconds(cooldown.Value);
        mIaStateManager.taunterKonpemos.Remove(this);
        yield return null;
    } 

    public override void Passive() // Explosion
    {
        Collider[] hitColliders = Physics.OverlapSphere(this.transform.position, rangeCapacity.Value);
        foreach (Collider collider in hitColliders) if (collider.GetComponent<Konpemo>() != null)
        {
            collider.GetComponent<Konpemo>().TakingDamage(5 * this.strength.Value);
        }
    }
}
