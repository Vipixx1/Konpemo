using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Beatowtron : Konpemo
{
    private float rangeHeal = 5f;
    public Beatowtron() : base(300f,300f, 0f, 2f, 10f, 5f, 10f, false)
    {
        // Beatowtron other stats ?
    }

    public override void Capacity() // Soin
    {
        float hpHealed = RandomHeal();

        Collider[] hitColliders = Physics.OverlapSphere(this.transform.position, rangeHeal, this.gameObject.layer);
        //HIGHLIGHT THE AREA WHERE THE ALLIED CAN BE HEAL
        foreach (Collider collider in hitColliders)
        {
            if (Input.GetMouseButtonDown(0))
            {
                //Raycast, if cible alliée, selectionne cet allié dans une variable, heal cet allié
                collider.GetComponent<Konpemo>().Healing(hpHealed);
            }
            
        }
    }

    private float RandomHeal()
    {
        return UnityEngine.Random.Range(1, 100);
    }

}
