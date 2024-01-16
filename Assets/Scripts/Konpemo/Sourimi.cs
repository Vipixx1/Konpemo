using UnityEngine;

public class Sourimi : Konpemo
{
    [SerializeField] private BallFoudre ballFoudrePrefab;
    [SerializeField] private Transform pointDeTir;
    
    [SerializeField] private Konpemo target; //Pour les tests

    public override void SetBaseStats()
    {
        health.BaseValue = 400f;
        health.SetCurrentHealth(400f);
        strength.BaseValue = 150f;
        defense.BaseValue = 0f;
        speed.BaseValue = 3f;
        attackSpeed.BaseValue = 0.3f;
        cooldown.BaseValue = 15f;
        rangeAttack.BaseValue = 3f;
        rangeView.BaseValue = 5f;
    }

    public override void Attack() // Ball'Foudre
    {
        BallFoudre ballFoudre = Instantiate(ballFoudrePrefab, pointDeTir.position, pointDeTir.rotation);
        Vector3 dirProj = (this.konpemoEnemy.transform.position - pointDeTir.position).normalized;
        ballFoudre.Setup(dirProj, this.strength.Value);
    }

    public override void Capacity() // Dash quantique
    {
        /*
        Dessine un cercle autour du Sourimi qui montre la range du Dash
        if (Input.GetMouseButtonDown(0))
        {
            Raycast de position de clique souris
            if (clique dans le cercle) 
            {
                Dash(position clique souris)
            }
            
            else (ie clique hors du cercle)
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
