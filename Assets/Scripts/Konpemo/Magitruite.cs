using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;


public class Magitruite : Konpemo
{
    private float speedDown = 1f;
    public Magitruite() : base(10f, 10f, 0f, 0.5f, 0f, 2f, 0f, false)
    {
        // Magitruite other stats ?
    }

    public override void Attack() // Gouttelette
    {
        Collider[] hitColliders = Physics.OverlapSphere(this.transform.position, 4f, 6);
        foreach (Collider collider in hitColliders.Where(collider => collider.gameObject.layer != this.gameObject.layer))
        {
            if (! collider.GetComponent<Konpemo>().isSlewDown)
            {
                collider.GetComponent<Konpemo>().SpeedDown(speedDown);
            }
            
        }
    }
    public override void Passive()
    {
        Debug.Log("Pluie magique");
    }

    public override void TakingDamage(float damageTaken) //2e passif !
    {
        System.Random rand = new System.Random();
        this.currentHp -= rand.Next(0, 2);
        if (this.currentHp <= 0) { Death(); } 
    }

    public override void Healing(float hpHealed)
    {
        System.Random rand = new System.Random();
        this.currentHp = Math.Min(baseHp, this.currentHp + rand.Next(0, 2));
    }

    public override IEnumerator Poison()
    {
        int timer = 0;
        while (timer < 10)
        {
            System.Random rand = new System.Random();
            this.currentHp -= rand.Next(0, 2);
            if (this.currentHp <= 0) { Death(); }
            timer++;
            yield return new WaitForSeconds(1);
        }
        if (timer >= 10) { isPoisoned  = false; }
    }
}
