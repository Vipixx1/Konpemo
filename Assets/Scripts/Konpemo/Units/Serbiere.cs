using UnityEngine;

public class Serbiere : Konpemo
{
    //rangeTrap = 3f;
    //nbTrap = 1
    //nbTrapMax = 2

    [SerializeField]
    private GameObject piege;
    private Vector3 localisationPiege;
    [SerializeField]
    private float offsetPiege = 0.1f;
    private GameObject mPiege;
    [SerializeField]
    private LayerMask masqueBleu;
    [SerializeField]
    private LayerMask masqueRouge;
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
        speed.BaseValue = 2f;
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

    public override void Attack() // Vortex Feu
    {
        if (1 << this.gameObject.layer == masqueBleu.value)

        {
            Collider[] hitColliders = Physics.OverlapSphere(konpemoEnemy.transform.position, rangeVortex, masqueRouge);
            foreach (Collider collider in hitColliders)
            {
                //Debug.Log(collider.GetComponent<Konpemo>());
                collider.GetComponent<Konpemo>().TakingDamage(this.strength.Value);
                vortexDeFeu.transform.position = konpemoEnemy.transform.position;
                vortexDeFeu.Play();
            }
        }
        else if (1 << this.gameObject.layer == masqueRouge.value)
        {
            Collider[] hitColliders = Physics.OverlapSphere(konpemoEnemy.transform.position, rangeVortex, masqueBleu);
            foreach (Collider collider in hitColliders)
            {
                collider.GetComponent<Konpemo>().TakingDamage(this.strength.Value);
                vortexDeFeu.transform.position = konpemoEnemy.transform.position;
                vortexDeFeu.Play();
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
