using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class Sourimi : Konpemo
{

    [SerializeField] private Transform pointDeTir;
    [SerializeField] private NavMeshAgent agent;
    private float distance;
    private float angle;
    private float limitDash = 1;
    private int limitIterationToDash = 10;
    private Vector3 localisationDash;

    public override void ChangeCapacityType()
    {
        this.capacityType = 3;//Capacité ciblant le sol
    }
    public override void SetBaseStats()
    {
        health.BaseValue = 400f;
        health.SetCurrentHealth(400f);
        strength.BaseValue = 150f;
        defense.BaseValue = 0f;
        speed.BaseValue = 5f;
        attackSpeed.BaseValue = 0.3f;
        cooldown.BaseValue = 15f;
        rangeAttack.BaseValue = 10f;
        rangeView.BaseValue = 15f;
    }

    public override void Attack() // Ball'Foudre
    {
        Projectile thunderBall = ProjectilePool.SharedInstance.GetPooledObject();
        if (thunderBall != null )
        {
            thunderBall.transform.position = pointDeTir.position;
            thunderBall.transform.rotation = pointDeTir.rotation;
            thunderBall.gameObject.SetActive(true);
            Vector3 dirProj = (this.konpemoEnemy.transform.position - pointDeTir.position).normalized;
            thunderBall.Setup(dirProj, this.strength.Value);
        }
        
        
    }

    public override void Capacity(Vector3? localisation = null) // Dash quantique
    {
        if (localisation.HasValue)
        {
            localisationDash = localisation.Value;
        }
        Dash(localisationDash);
    }

    private void Dash(Vector3 position)
    {
        if (agent.Warp(position))
        {
            //Debug.Log("Dash réalisé avec succès")
        }
        else
        {
            for (int i = 0; i < limitIterationToDash; i++)
            {
                angle = Random.Range(0f, 2f * Mathf.PI);
                distance = Random.Range(0f, limitDash);
                float x = position.x + distance * Mathf.Cos(angle);
                float y = position.y + distance * Mathf.Sin(angle);
                localisationDash = new Vector3(x, y, position.z);
                if(agent.Warp(localisationDash))
                {
                    break;
                }
            }
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)) 
        {
            this.Attack();
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            this.health.GetHealthDebug();
        }
    }

}
