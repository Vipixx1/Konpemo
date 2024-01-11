using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using static Unity.VisualScripting.Member;
using Unity.VisualScripting;
using UnityEngine.UIElements;

public class Sourimi : Konpemo
{
    [SerializeField] private BallFoudre ballFoudrePrefab;
    [SerializeField] private Transform pointDeTir;
    
    [SerializeField] private Konpemo target; //Pour les tests

    public Sourimi() : base(400f, 400f, 0f, 3f, 150f, 3f, 15f, false)
    {
        //this.range = 3f;
        //Sourimi other stats ?
    }

    public override void Attack() //Ball'Foudre
    {
        BallFoudre ballFoudre = Instantiate(ballFoudrePrefab, pointDeTir.position, pointDeTir.rotation);
        Vector3 dirProj = (this.konpemoEnemy.transform.position - pointDeTir.position).normalized;
        ballFoudre.Setup(dirProj, this.currentDamage);
    }

    public override void Capacity() //Dash quantique
    {
        /*
        Dessine un cercle autour du Sourimi qui montre la range du Dash
        if (Input.GetMouseButtonDown(0))
        {
            Raycast de position de clique souris
            if (cliqué dans le cercle) 
            {
                Dash(position clique souris)
            }
            
            else (ie cliqué hors du cercle)
            {
                Nouvelle position, la plus proche du clique et qui est dans le cercle
                Dash(Nouvelle position)
        }     
        */
    }

    private void Dash(Vector3 position)
    {
        /*
        this.Warp(position raycast de souris);
        if (!this.Warp(position raycast de souris))
        {
            Prend la position accessible la plus proche de la position de la souris
                    if (distance entre les deux points <= seuil de tolérance) {
                Warp sur cette position)
                    else { Ne fait rien (mais CD quand même) }
        }
        */
    }

    // Pour faire des tests :
    private void Start()
    {
        this.SetTarget(target);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)) 
        {
            this.Attack();
        }
    }

}
