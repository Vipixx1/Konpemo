using UnityEngine;

public class Beatowtron : Konpemo
{
    private float rangeHeal = 3f;
    public override void SetBaseStats()
    {
        health.BaseValue = 300f;
        health.SetCurrentHealth(300f);
        strength.BaseValue = 10f;
        defense.BaseValue = 0f;
        speed.BaseValue = 2f;
        attackSpeed.BaseValue = 0.2f;
        cooldown.BaseValue = 10f;
        rangeAttack.BaseValue = 8f;
        rangeView.BaseValue = 15f;
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
