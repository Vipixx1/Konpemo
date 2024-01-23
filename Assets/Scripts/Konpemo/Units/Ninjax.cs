using UnityEngine;

public class Ninjax : Konpemo
{
    [SerializeField] private Transform pointDeTir;

    public override void SetBaseStats()
    {
        health.BaseValue = 350f;
        health.SetCurrentHealth(350f);
        strength.BaseValue = 15f;
        defense.BaseValue = 3f;
        speed.BaseValue = 5f;
        attackSpeed.BaseValue = 3f;
        cooldown.BaseValue = 25f;
        rangeAttack.BaseValue = 10f;
        rangeView.BaseValue = 15f;
    }

    public override void SetCapacityType()
    {
        this.capacityType = 1;
    }

    public override void Attack() // Piqûre
    {
        Projectile needle = ProjectilePool.SharedInstance.GetPooledObject(ProjectileType.Piqure);
        if (needle != null)
        {
            needle.transform.SetPositionAndRotation(pointDeTir.position, pointDeTir.rotation);
            needle.gameObject.SetActive(true);
            Vector3 dirProj = (this.konpemoEnemy.transform.position - pointDeTir.position).normalized;
            needle.Setup(dirProj, this.strength.Value);
        }
    }

    public override void Capacity(Vector3? localisation = null) // Brouillard
    {

    }

}
