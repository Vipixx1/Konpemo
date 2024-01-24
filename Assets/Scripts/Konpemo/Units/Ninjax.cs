using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ninjax : Konpemo
{
    [SerializeField] private Transform pointDeTir;

    [SerializeField] private Transform pointTir;

    [SerializeField] private GameObject fog;

    private IAStateManager iaStateManager;
    private List<Konpemo> enemyKonpemos;
    private GameObject mFog;
    public override void SetBaseStats()
    {
        health.BaseValue = 350f;
        health.SetCurrentHealth(350f);
        strength.BaseValue = 15f;
        defense.BaseValue = 3f;
        speed.BaseValue = 7f;
        attackSpeed.BaseValue = 3f;

        cooldown.BaseValue = 25f;

        rangeAttack.BaseValue = 7.5f;
        rangeCapacity.BaseValue = 5f;
        rangeView.BaseValue = 10f;
    }

    public override void SetCapacityTypeAndName()
    {
        
        this.capacityType = CapacityType.NoClick;
        this.nameKonpemo = KonpemoSpecies.Ninjax.ToString();
    }

    public override void Attack() // Piqure
    {
        Projectile needle = ProjectilePool.SharedInstance.GetPooledObject(ProjectileType.Piqure);

        if (needle != null)
        {
            needle.transform.SetPositionAndRotation(pointDeTir.position, pointDeTir.rotation);
            needle.gameObject.layer = this.gameObject.layer;
            needle.gameObject.SetActive(true);
            Vector3 dirProj = (this.konpemoEnemy.transform.position - pointDeTir.position).normalized;
            needle.Setup(dirProj, this.strength.Value);
        }
    }

    public override void Capacity(Vector3? localisation = null) // Brouillard
    {
        mFog = Instantiate(fog);
        mFog.transform.position = this.transform.position;
    }
}
