using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoupeVent : Projectile
{
    private void Start()
    {
        this.projType = ProjectileType.CoupeVent;
    }

    public override void Setup(Vector3 dirProj, float damageProj)
    {
        this.dirProj = dirProj;
        this.damageProj = damageProj;
        this.speedProj = 500f;
        this.numberEnemyHit = 0;
        this.numberMax = 1;
    }
}
