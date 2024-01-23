using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class Sourimi : Konpemo
{
    [SerializeField]
	private Transform pointDeTir;
    [SerializeField]
    private ParticleSystem dashAnimation;

    private float distance;
    private float angle;
    private float limitDash = 0.3f;
    private int limitIterationToDash = 10;
    private Vector3 localisationDash;

    public override void SetBaseStats()
    {
        health.BaseValue = 400f;
        health.SetCurrentHealth(400f);
        strength.BaseValue = 150f;
        defense.BaseValue = 0f;
        speed.BaseValue = 7f;
        attackSpeed.BaseValue = 0.3f;

        cooldown.BaseValue = 15f;

        rangeAttack.BaseValue = 7.5f;
        rangeCapacity.BaseValue = 7.5f;
        rangeView.BaseValue = 10f;
    }
	
	public override void SetCapacityType()
    {
        this.capacityType = CapacityType.ClickOnGround;
    }

    public override void Attack() // Ball'Foudre
    {
        Projectile thunderBall = ProjectilePool.SharedInstance.GetPooledObject(ProjectileType.BallFoudre);
        if (thunderBall != null)
        {
            thunderBall.transform.SetPositionAndRotation(pointDeTir.position, pointDeTir.rotation);
            thunderBall.gameObject.layer = this.gameObject.layer;
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
            dashAnimation.Play();
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
                    dashAnimation.Play();
                    break;
                }
            }
			
        }
    }
}
