using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallFoudre : Projectile
{
    private void Start()
    {
        this.projType = ProjectileType.BallFoudre;
    }

    public override void Setup(Vector3 dirProj, float damageProj)
    {
        this.dirProj = dirProj;
        this.damageProj = damageProj;
        this.speedProj = 100f;
        this.numberEnemyHit = 0;
        this.numberMax = 1;
        
    }
}
