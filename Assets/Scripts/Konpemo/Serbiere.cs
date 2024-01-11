using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Serbiere : Konpemo
{
    //private float rangeAtk;
    public Serbiere() : base(300f, 300f, 0f, 2f, 100f, 2f, 30f, false)
    {
        //this.rangeAtk = 2f;
        //this.rangeTrap = 2f;
        //this.nbTrap = 1
        //this.npTrapMax = 2
        //Serbiere other stats ?
    }

    public override void Attack() // Vortex Feu
    {
        if (this.gameObject.layer == 7)
        {
            Collider[] hitColliders = Physics.OverlapSphere(konpemoEnemy.transform.position, 5f, 8);
            foreach (Collider collider in hitColliders)
            {
                collider.GetComponent<Konpemo>().TakingDamage(this.currentDamage);
            }
        }
        else if (this.gameObject.layer == 8)
        {
            Collider[] hitColliders = Physics.OverlapSphere(konpemoEnemy.transform.position, 5f, 7);
            foreach (Collider collider in hitColliders)
            {
                collider.GetComponent<Konpemo>().TakingDamage(this.currentDamage);
            }
        }
    }

    public override void Capacity() // Piège de Breizh
    {
        /*
        Raycast à la position de la souris jusqu'à la position du terrain ciblé.
        Instancie une version temporaire et transparente du piège, elle suit la position de la souris/terrain ciblé.
        Si on ne peut pas poser le piège (terrain défavorable, ennemie ?, allié ?), piège en rouge et impossibilité de cliquer.
        Si on peut, piège en vert transparent.
        
        Si clique gauche, piège définitif instancié à cette position.
        */
    }

}
