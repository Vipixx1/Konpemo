using UnityEngine;

public class Caillebonbon : Konpemo
{
    [SerializeField] private Transform pointDeTir;

    public override void SetBaseStats()
    {
        health.BaseValue = 200f;
        health.SetCurrentHealth(200f);
        strength.BaseValue = 40f;
        defense.BaseValue = 3f;
        speed.BaseValue = 4f;
        attackSpeed.BaseValue = 1/0.75f;
        cooldown.BaseValue = 20f;
        rangeAttack.BaseValue = 10f;
        rangeView.BaseValue = 15f;
    }

    public override void Attack() // Coupe Vent
    {
        animator.SetTrigger("Attack");
        Projectile windBlade = ProjectilePool.SharedInstance.GetPooledObject(ProjectileType.CoupeVent);
        if (windBlade != null)
        {
            windBlade.transform.SetPositionAndRotation(pointDeTir.position, pointDeTir.rotation);
            windBlade.gameObject.SetActive(true);
            Vector3 dirProj = (this.konpemoEnemy.transform.position - pointDeTir.position).normalized;
            windBlade.Setup(dirProj, this.strength.Value);
        }
    }

    public override void Capacity(Vector3? localisation = null)  // Atterrissage
    {
        Debug.Log("Posons-nous un petit peu");
    }

    public override void Passive() // Flying
    {
        Debug.Log("Tut tut les rageux");
    }

}
