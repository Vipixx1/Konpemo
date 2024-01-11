using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Caspow : Konpemo
{
    public Caspow() : base(350f, 350f, 5f, 4f, 50f, 1f, 15f, false)
    {
        // Caspow other stats ?
    }
    public override void Attack() // Paralysie 1 chance sur 3
    {
        this.konpemoEnemy.TakingDamage(this.currentDamage);
        System.Random rand = new System.Random();
        int nbParalysed = rand.Next(0, 3);
        if (nbParalysed == 0) { this.konpemoEnemy.isParalysed = true; }
    }

    public override void Capacity() // Toxic, empoisonne l'ennemi target du Konpemo (Autre choix : empoisonne tous les ennemis dans une range)
    {
        if (this.konpemoEnemy.isPoisoned == false)
        {
            SetCooldown(this.cooldown);
            this.konpemoEnemy.Poisoning();
            
        }
        
    }

    
}
