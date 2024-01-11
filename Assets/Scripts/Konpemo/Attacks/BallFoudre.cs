using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BallFoudre : Projectile
{
    public override void Setup(Vector3 dirProj, float damageProj)
    {
        this.dirProj = dirProj;
        this.damageProj = damageProj;
        this.speedProj = 200f;
        this.numberEnemyHit = 0;
        this.numberMax = 1;
        Destroy(this.gameObject, 5f);
    }
}
