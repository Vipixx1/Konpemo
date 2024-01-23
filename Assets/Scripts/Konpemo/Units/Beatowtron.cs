using UnityEngine;

public class Beatowtron : Konpemo
{
    [SerializeField] private ParticleSystem healingEffect;

    public override void SetBaseStats()
    {
        health.BaseValue = 300f;
        health.SetCurrentHealth(300f);
        strength.BaseValue = 10f;
        defense.BaseValue = 0f;
        speed.BaseValue = 4f;
        attackSpeed.BaseValue = 0.2f;

        cooldown.BaseValue = 10f;

        rangeAttack.BaseValue = 3f;
        rangeCapacity.BaseValue = 7.5f;
        rangeView.BaseValue = 10f;
    }

    public override void SetCapacityType()
    {
        this.capacityType = CapacityType.NoClick;
    }

    public override void Capacity(Vector3? localisation = null)  // Soin
    {
        float hpHealed = RandomHeal();

        healingEffect.Play();
        Collider[] hitColliders = Physics.OverlapSphere(this.transform.position, rangeCapacity.Value);
        foreach (Collider collider in hitColliders) if (collider.GetComponent<Konpemo>() && this.gameObject.layer == collider.gameObject.layer)
        {
            collider.GetComponent<Konpemo>().Healing(hpHealed);
        }
    }

    private float RandomHeal()
    {
        return UnityEngine.Random.Range(1, 100);
    }
}
