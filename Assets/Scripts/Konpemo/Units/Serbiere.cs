using UnityEngine;

public class Serbiere : Konpemo
{
    //rangeTrap = 3f;
    //nbTrap = 1
    //nbTrapMax = 2

    public override void SetBaseStats()
    {
        health.BaseValue = 300f;
        health.SetCurrentHealth(300f);
        strength.BaseValue = 100f;
        defense.BaseValue = 0f;
        speed.BaseValue = 2f;
        attackSpeed.BaseValue = 0.5f;
        cooldown.BaseValue = 30f;
        rangeAttack.BaseValue = 10f;
        rangeView.BaseValue = 15f;
    }

    public override void Attack() // Vortex Feu
    {
        if (this.gameObject.layer == 7)
        {
            Collider[] hitColliders = Physics.OverlapSphere(konpemoEnemy.transform.position, 5f, 8);
            foreach (Collider collider in hitColliders)
            {
                collider.GetComponent<Konpemo>().TakingDamage(this.strength.Value);
            }
        }
        else if (this.gameObject.layer == 8)
        {
            Collider[] hitColliders = Physics.OverlapSphere(konpemoEnemy.transform.position, 5f, 7);
            foreach (Collider collider in hitColliders)
            {
                collider.GetComponent<Konpemo>().TakingDamage(this.strength.Value);
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
