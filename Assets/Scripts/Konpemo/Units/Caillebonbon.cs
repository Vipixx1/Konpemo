using UnityEngine;

public class Caillebonbon : Konpemo
{
    public override void SetBaseStats()
    {
        health.BaseValue = 200f;
        health.SetCurrentHealth(200f);
        strength.BaseValue = 40f;
        defense.BaseValue = 3f;
        speed.BaseValue = 4f;
        attackSpeed.BaseValue = 1/0.75f;
        cooldown.BaseValue = 20f;
        rangeAttack.BaseValue = 10f;
        rangeView.BaseValue = 15f;
    }
    public override void Attack() // Coupe Vent
    {

    }

    public override void Capacity(Vector3? localisation = null)  // Atterrissage
    {
        Debug.Log("Posons-nous un petit peu");
    }

    public override void Passive() // Flying
    {
        Debug.Log("Tut tut les rageux");
    }

}
