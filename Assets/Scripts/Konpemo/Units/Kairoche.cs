using UnityEngine;
using System.Collections;

public class Kairoche : Konpemo
{
    [SerializeField] private ParticleSystem explosionEffect;
    [SerializeField] private ParticleSystem tauntEffect;

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
        rangeCapacity.BaseValue = 7.5f;
        rangeView.BaseValue = 10f;
    }

    public override void SetCapacityTypeAndName()
    {
        this.capacityType = CapacityType.NoClick;
        this.nameKonpemo = KonpemoSpecies.Kairoche.ToString();
    }

    public override void Capacity(Vector3? localisation = null) // Taunt
    {
        tauntEffect.Play();

        Collider[] hitColliders = Physics.OverlapSphere(this.transform.position, rangeCapacity.Value);
        foreach (Collider collider in hitColliders) if (collider.GetComponent<Konpemo>() != null)
        {
            // Ne marche que pour l'utilisation de la capacite par un Kairoche allie pour le moment...
            if(iaStateManager = collider.GetComponent<IAStateManager>())
            {
                StartCoroutine(TauntCoroutine(iaStateManager));
            }
        }
    }

    public IEnumerator TauntCoroutine(IAStateManager mIaStateManager)
    {
        mIaStateManager.taunterKonpemos.Add(this);
        yield return new WaitForSeconds(cooldown.Value);
        mIaStateManager.taunterKonpemos.Remove(this);
        yield return null;
    } 

    public override void Passive() // Explosion
    {
        explosionEffect.Play();

        Collider[] hitColliders = Physics.OverlapSphere(this.transform.position, rangeCapacity.Value);
        foreach (Collider collider in hitColliders) if (collider.GetComponent<Konpemo>() != null && collider.gameObject != this.gameObject)
        {
            collider.GetComponent<Konpemo>().TakingDamage(5 * this.strength.Value);
        }
    }

    public override void Death()
    {
        Passive();
        onDeath.Invoke(this);
        this.gameObject.SetActive(false);
    }
}
