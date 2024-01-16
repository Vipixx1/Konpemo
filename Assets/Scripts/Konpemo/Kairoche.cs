using UnityEngine;
using System.Linq;

public class Kairoche : Konpemo
{
    public override void SetBaseStats()
    {
        health.BaseValue = 650f;
        health.SetCurrentHealth(650f);
        strength.BaseValue = 30f;
        defense.BaseValue = 10f;
        speed.BaseValue = 1f;
        attackSpeed.BaseValue = 1f;
        cooldown.BaseValue = 15f;
        rangeAttack.BaseValue = 1f;
        rangeView.BaseValue = 5f;
    }
    
    public override void Capacity() // Taunt
    {
        Collider[] hitColliders = Physics.OverlapSphere(this.transform.position, 5f, 6);
        foreach (Collider collider in hitColliders.Where(collider => collider.gameObject.layer != this.gameObject.layer))
        {
            collider.GetComponent<Konpemo>().SetTarget(this);
        }

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
