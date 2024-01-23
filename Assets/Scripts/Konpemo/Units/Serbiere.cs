using UnityEngine;

public class Serbiere : Konpemo
{


    [SerializeField]
    private GameObject piege;

    private Vector3 localisationPiege;

    [SerializeField]
    private float offsetPiege = 0.1f;
    private GameObject mPiege;

    [SerializeField]
    ParticleSystem vortexDeFeu;

    [SerializeField]
    private float rangeVortex = 3;
    [SerializeField]
    private bool seeGizmoRangeVortex = false;

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

    public override void SetCapacityType()
    {
        this.capacityType = CapacityType.ClickOnGround;
    }

    public override void Attack() // VortexDeFeu
    {
        Collider[] hitColliders = Physics.OverlapSphere(konpemoEnemy.transform.position, rangeVortex);
        vortexDeFeu.transform.position = konpemoEnemy.transform.position;
        vortexDeFeu.Play();
		
        foreach (Collider collider in hitColliders) if (collider.GetComponent<Konpemo>() != null)
        { 
            if (this.gameObject.layer != collider.gameObject.layer)
            {
                collider.GetComponent<Konpemo>().TakingDamage(this.strength.Value);
            }
        }
    }

    public override void Capacity(Vector3? localisation) // Piège de Breizh
    {
        if(localisation.HasValue)
        {
            localisationPiege = localisation.Value;
            localisationPiege.y += offsetPiege;
        }
        mPiege = Instantiate(piege, localisationPiege, Quaternion.identity);
        mPiege.gameObject.layer = this.gameObject.layer;
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
