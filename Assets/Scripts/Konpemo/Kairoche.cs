using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class Kairoche : Konpemo
{
    public Kairoche() : base(650f, 650f, 10f, 1f, 30f, 1f, 15f, false)
    {
        // Kairoche other stats ?
    }
    
    public override void Capacity() // Taunt
    {
        Collider[] hitColliders = Physics.OverlapSphere(this.transform.position, 5f, 6);
        foreach (Collider collider in hitColliders.Where(collider => collider.gameObject.layer != this.gameObject.layer))
        {
            collider.GetComponent<Konpemo>().SetTarget(this);
        }

    }

    public override void Passive() // MACRON Explosion
    {
        Collider[] hitColliders = Physics.OverlapSphere(this.transform.position, 5f, LayerMask.GetMask("Konpemo"));

        foreach (Collider collider in hitColliders)
        {
            collider.GetComponent<Konpemo>().TakingDamage(5 * this.currentDamage);
        }
    }
}
