using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static Unity.VisualScripting.Member;

public abstract class Projectile : MonoBehaviour
{
    protected Vector3 vector;
    protected Vector3 dirProj;

    protected float damageProj;
    protected float speedProj;

    protected int numberEnemyHit;
    protected int numberMax;

    public ProjectileType projType;

    public abstract void Setup(Vector3 dirProj, float damageProj);

    public virtual void OnDisable()
    {
        this.GetComponent<Rigidbody>().velocity = Vector3.zero;
        this.numberEnemyHit = 0;
    }

    private void Update()
    {
        Vector3 vector = speedProj * Time.deltaTime * this.dirProj;
        this.GetComponent<Rigidbody>().AddForce(vector.x, vector.y, vector.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Rajouter une condition si c'est un Konpemo ennemi qui est touch�. Traverse les alli�s, est bloqu� par les murs.

        if (other.TryGetComponent<Konpemo>(out var konpemo))
        {
            if (konpemo.gameObject.layer != this.gameObject.layer)
            {
                konpemo.TakingDamage(damageProj);
                numberEnemyHit++;
                if (numberEnemyHit >= numberMax)
                {
                    this.gameObject.SetActive(false);
                }
            }
        }
        else 
        {
            this.gameObject.SetActive(false);
        }
        
    }

}

public enum ProjectileType
{
    BallFoudre,
    Piqure,
    CoupeVent,
}
