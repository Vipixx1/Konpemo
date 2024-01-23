using UnityEngine;
public class Caspow : Konpemo
{
    [SerializeField] private ParticleSystem toxicEffect;

    public override void SetBaseStats()
    {
        health.BaseValue = 350f;
        health.SetCurrentHealth(350f);
        strength.BaseValue = 50f;
        defense.BaseValue = 5f;
        speed.BaseValue = 6f;
        attackSpeed.BaseValue = 1f;

        cooldown.BaseValue = 15f;

        rangeAttack.BaseValue = 3f;
        rangeCapacity.BaseValue = 7.5f;
        rangeView.BaseValue = 10f;
    }

    public override void SetCapacityTypeAndName()
    {
        this.capacityType = CapacityType.NoClick;
        this.nameKonpemo = KonpemoSpecies.Caspow.ToString();
    }

    public override void Capacity(Vector3? localisation = null)  // Toxic, empoisonne tous les ennemis dans une range
    {
        toxicEffect.Play();

        Collider[] hitColliders = Physics.OverlapSphere(this.transform.position, rangeCapacity.Value);
        foreach (Collider collider in hitColliders) if (collider.GetComponent<Konpemo>() && this.gameObject.layer != collider.gameObject.layer)
        {
            konpemoEnemy = collider.GetComponent<Konpemo>();
            if (konpemoEnemy.isPoisoned == false)
            {
                konpemoEnemy.Poisoning(10f, 10);

            }
        }
   
    }
}
