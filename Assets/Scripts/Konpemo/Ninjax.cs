using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using static UnityEngine.GraphicsBuffer;

public class Ninjax : Konpemo
{
    [SerializeField] private Piqure piqurePrefab;
    [SerializeField] private Transform pointDeTir;

    [SerializeField] private Konpemo target; //Pour les tests

    public Ninjax() : base(350f, 350f, 3f, 5f, 15f, 0.3f, 25f, false)
    {
        //this.range = 2f;
        //Ninjax other stats ?
    }
    public override void Attack() // Piqûre
    {
        Piqure piqure = Instantiate(piqurePrefab, pointDeTir.position, pointDeTir.rotation);
        Vector3 dirProj = (this.konpemoEnemy.transform.position - pointDeTir.position).normalized;
        piqure.Setup(dirProj, this.currentDamage);
    }

    public override void Capacity() // Brouillard
    {

    }

    // Pour faire des tests :
    private void Start()
    {
        this.SetTarget(target);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            this.Attack();
        }
    }
}
