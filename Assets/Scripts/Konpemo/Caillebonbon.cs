using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Caillebonbon : Konpemo
{
    //private float rangeAtk;
    public Caillebonbon() : base(200f, 200f, 3f, 4f, 40f, 0.75f, 20f, false)
    {
        //this.rangeAtk = 2f;
        // Caillebonbon other stats ?
    }
    public override void Attack() // Coupe Vent
    {

    }

    public override void Capacity() // Atterrissage
    {
        Debug.Log("Posons-nous un petit peu");
    }

    public override void Passive() // Flying
    {
        Debug.Log("Tut tut les rageux");
    }

}
