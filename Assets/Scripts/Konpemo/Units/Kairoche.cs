using UnityEngine;
using System.Linq;
using System.Collections.Generic;
using System.Collections;

public class Kairoche : Konpemo
{
    [SerializeField]
    private LayerMask redMask;
    private IAStateManager iaStateManager;
    public override void SetBaseStats()
    {
        health.BaseValue = 650f;
        health.SetCurrentHealth(650f);
        strength.BaseValue = 30f;
        defense.BaseValue = 10f;
        speed.BaseValue = 1f;
        attackSpeed.BaseValue = 1f;
        cooldown.BaseValue = 15f;
        rangeAttack.BaseValue = 5f;
        rangeView.BaseValue = 15f;
    }
    public override void ChangeCapacityType()
    {
        this.capacityType = 1;//Capacité ciblant rien du tout
    }
    public override void Capacity(Vector3? localisation = null) // Taunt
    {
        Collider[] hitColliders = Physics.OverlapSphere(this.transform.position, rangeView.Value, redMask);
        foreach (Collider collider in hitColliders)
        {
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
        Collider[] hitColliders = Physics.OverlapSphere(this.transform.position, 5f, LayerMask.GetMask("Konpemo"));

        foreach (Collider collider in hitColliders)
        {
            collider.GetComponent<Konpemo>().TakingDamage(5 * this.strength.Value);
        }
    }
}
