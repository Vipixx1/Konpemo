using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static Unity.VisualScripting.Member;

public abstract class Projectile : MonoBehaviour
{
    protected Vector3 dirProj;

    protected float damageProj;
    protected float speedProj;

    protected int numberEnemyHit;
    protected int numberMax;

    public abstract void Setup(Vector3 dirProj, float damageProj);
   
    private void Update()
    {
        Vector3 force = speedProj * Time.deltaTime * this.dirProj;
        this.GetComponent<Rigidbody>().AddForce(force.x, force.y, force.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Rajouter une condition si c'est un Konpemo ennemi qui est touché. Traverse les alliés, est bloqué par les murs.
        Konpemo konpemo = other.GetComponent<Konpemo>();
        konpemo.TakingDamage(damageProj);
        numberEnemyHit++;
        if (numberEnemyHit >= numberMax) 
        {
            Destroy(this.gameObject);
        }
        
    }
}
