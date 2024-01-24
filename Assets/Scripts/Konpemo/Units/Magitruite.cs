using System.Collections;
using UnityEngine;

public class Magitruite : Konpemo
{

    [SerializeField] private ParticleSystem splashEffect;

    private readonly float percentSpeedReduction = -0.1f;
    private readonly float durationSpeedReduction = 5f;

    public override void SetBaseStats()
    {
        health.BaseValue = 10f;
        health.SetCurrentHealth(10f);
        strength.BaseValue = 0f;
        defense.BaseValue = 0f;
        speed.BaseValue = 2f;
        attackSpeed.BaseValue = 0.5f;

        cooldown.BaseValue = 0f;

        rangeAttack.BaseValue = 5f;
        rangeCapacity.BaseValue = 0f;
        rangeView.BaseValue = 10f;
    }
    public override void SetCapacityTypeAndName()
    {
        this.capacityType = CapacityType.NoCapacity;
        this.nameKonpemo = KonpemoSpecies.Magitruite.ToString();
    }

    public override void Attack() // Gouttelette
    {
        splashEffect.Play();

        Collider[] hitColliders = Physics.OverlapSphere(this.transform.position, rangeAttack.Value);

        foreach (Collider collider in hitColliders) if (collider.GetComponent<Konpemo>() != null && collider.gameObject.layer != this.gameObject.layer)
        {
            if (collider.GetComponent<Konpemo>().speed.StatModifiers.Count > 0)
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
            StartCoroutine(Gouttelette(collider.GetComponent<Konpemo>())); 
        }
    }

    public IEnumerator Gouttelette(Konpemo konpemo)
    {
        konpemo.speed.AddModifier(new StatModifier(percentSpeedReduction, StatModType.PercentAdd, "Gouttelette"));
        yield return new WaitForSeconds(durationSpeedReduction);
        konpemo.speed.RemoveAllModifiersFromSource("Gouttelette");

    }
    public override void Passive()
    {
        Debug.Log("Pluie magique");
    }

    public override void TakingDamage(float damageTaken)
    {
        System.Random rand = new();
        base.TakingDamage(rand.Next(0, 2));

        if (this.health.GetCurrentHealth() < 0) { Death(); }
        // No animation for Death...

    }

    public override void Healing(float hpHealed)
    {
        System.Random rand = new();
        base.Healing(rand.Next(0, 2));
    }

    public override IEnumerator Poison(float poisonTickDamage, int poisonDuration)
    {
        int timer = 0;
        while (timer < poisonDuration)
        {
            System.Random rand = new();
            this.TakingDamage(rand.Next(0, 2));
            timer++;
            yield return new WaitForSeconds(1);
        }
        if (timer >= poisonDuration) { isPoisoned  = false; }
    }
}
