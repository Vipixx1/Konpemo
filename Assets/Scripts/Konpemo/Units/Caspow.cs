
public class Caspow : Konpemo
{
    public override void SetBaseStats()
    {
        health.BaseValue = 350f;
        health.SetCurrentHealth(350f);
        strength.BaseValue = 50f;
        defense.BaseValue = 5f;
        speed.BaseValue = 4f;
        attackSpeed.BaseValue = 1f;
        cooldown.BaseValue = 15f;
        rangeAttack.BaseValue = 5f;
        rangeView.BaseValue = 15f;
    }

    public override void Attack() // Paralysie 1 chance sur 3
    {
        this.konpemoEnemy.TakingDamage(this.strength.Value);
        System.Random rand = new System.Random();
        int nbParalysed = rand.Next(0, 3);
        if (nbParalysed == 0) { this.konpemoEnemy.isParalysed = true; }
    }

    public override void Capacity() // Toxic, empoisonne l'ennemi target du Konpemo (Autre choix : empoisonne tous les ennemis dans une range)
    {
        if (this.konpemoEnemy.isPoisoned == false)
        {
            SetCooldown(this.cooldown.Value);
            this.konpemoEnemy.Poisoning(10f, 10);
            
        }
        
    }

    
}
