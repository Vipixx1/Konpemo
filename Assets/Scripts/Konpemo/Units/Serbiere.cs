using UnityEngine;

public class Serbiere : Konpemo
{

    [SerializeField] private ParticleSystem vortexAnimation;
    private readonly float rangeVortex = 3;

    [SerializeField] private GameObject trap;
    private Vector3 trapLocalisation;
    private readonly float trapOffset = 0.1f;


    [SerializeField] private bool seeGizmoRangeVortex = false;

    public override void SetBaseStats()
    {
        health.BaseValue = 300f;
        health.SetCurrentHealth(300f);
        strength.BaseValue = 100f;
        defense.BaseValue = 0f;
        speed.BaseValue = 4f;
        attackSpeed.BaseValue = 0.33f;

        cooldown.BaseValue = 30f;

        rangeAttack.BaseValue = 7f;
        rangeCapacity.BaseValue = 7.5f;
        rangeView.BaseValue = 10f;
    }

    public override void SetCapacityTypeAndName()
    {
        this.capacityType = CapacityType.ClickOnGround;
        this.nameKonpemo = KonpemoSpecies.Serbiere.ToString();
    }

    public override void Attack() // VortexDeFeu
    {
        Collider[] hitColliders = Physics.OverlapSphere(konpemoEnemy.transform.position, rangeVortex);
        vortexAnimation.transform.position = konpemoEnemy.transform.position;
        vortexAnimation.Play();
		
        foreach (Collider collider in hitColliders) if (collider.GetComponent<Konpemo>() != null)
        { 
            if (this.gameObject.layer != collider.gameObject.layer)
            {
                collider.GetComponent<Konpemo>().TakingDamage(this.strength.Value);
            }
        }
    }

    public override void Capacity(Vector3? localisation) // Piege de Breizh
    {
        if (localisation.HasValue)
        {
            trapLocalisation = localisation.Value;
            trapLocalisation.y += trapOffset;
        }

        GameObject mPiege = Instantiate(trap, trapLocalisation, Quaternion.identity);
        mPiege.layer = this.gameObject.layer;
    }

    public void OnDrawGizmos()
    {
        if(seeGizmoRangeVortex)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(konpemoEnemy.transform.position, rangeVortex);
        }
    }
}
