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

    public override void Capacity() // Pi�ge de Breizh
    {
        /*
        Raycast � la position de la souris jusqu'� la position du terrain cibl�.
        Instancie une version temporaire et transparente du pi�ge, elle suit la position de la souris/terrain cibl�.
        Si on ne peut pas poser le pi�ge (terrain d�favorable, ennemie ?, alli� ?), pi�ge en rouge et impossibilit� de cliquer.
        Si on peut, pi�ge en vert transparent.
        
        Si clique gauche, pi�ge d�finitif instanci� � cette position.
        */
    }

}
