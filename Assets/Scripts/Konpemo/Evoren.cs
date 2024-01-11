using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using static UnityEngine.GraphicsBuffer;

public class Evoren : Konpemo
{
    public Evoren() : base(500f, 500f, 5f, 3f, 40f, 1f, 15f, false)
    {
        // Evoren other stats ?
    }

    public override void Capacity() // Gonflette
    {
        StartCoroutine(Gonflette());
        SetCooldown(cooldown);
    }

    public IEnumerator Gonflette()
    {
        this.currentDamage += 20f;
        this.currentDef += 3f;
        yield return new WaitForSeconds(10);
        this.currentDamage -= 20f;
        this.currentDef -= 3f;
    }

    private void Start()
    {
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("Evoren HP: " + currentHp);
            Debug.Log("Evoren ATK: " + currentDamage);
            Debug.Log("Evoren DEF: " + currentDef);
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            Capacity();
        }
    }
}
