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
