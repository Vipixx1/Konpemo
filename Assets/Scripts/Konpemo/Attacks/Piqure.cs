using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piqure : Projectile
{
    private void Start()
    {
        this.projType = ProjectileType.Piqure;
    }

    public override void Setup(Vector3 dirProj, float damageProj)
    {
        this.dirProj = dirProj;
        this.damageProj = damageProj;
        this.speedProj = 3000f;
        this.numberEnemyHit = 0;
        this.numberMax = 100;
    }
}
