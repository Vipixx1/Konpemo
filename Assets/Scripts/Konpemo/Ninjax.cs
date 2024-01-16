using UnityEngine;

public class Ninjax : Konpemo
{
    [SerializeField] private Piqure piqurePrefab;
    [SerializeField] private Transform pointDeTir;

    [SerializeField] private Konpemo target; //Pour les tests

    public override void SetBaseStats()
    {
        health.BaseValue = 350f;
        health.SetCurrentHealth(350f);
        strength.BaseValue = 15f;
        defense.BaseValue = 3f;
        speed.BaseValue = 5f;
        attackSpeed.BaseValue = 3f;
        cooldown.BaseValue = 25f;
        rangeAttack.BaseValue = 3f;
        rangeView.BaseValue = 5f;
    }
    public override void Attack() // Piqûre
    {
        Piqure piqure = Instantiate(piqurePrefab, pointDeTir.position, pointDeTir.rotation);
        Vector3 dirProj = (this.konpemoEnemy.transform.position - pointDeTir.position).normalized;
        piqure.Setup(dirProj, this.strength.Value);
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
