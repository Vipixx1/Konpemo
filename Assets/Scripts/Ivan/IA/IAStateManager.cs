using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IAStateManager : MonoBehaviour
{
    public Konpemo konpemo;
    public NavMeshAgent agent;

    public List<Konpemo> taunterKonpemos = new List<Konpemo>();
    public List<Konpemo> invisbleKonpemos = new List<Konpemo>();

    public LayerMask enemyLayerMask;
    public Konpemo target;

    public Konpemo king;
    private KingManager kingManager;
 
    IABaseState currentState;
    public IAIdleState IAIdleState = new();
    public IAAttackingState IAAttackingState = new();
    public IAMovingState IAMovingState = new();
    public IAPatrollingState IAAPatrollingState = new();

    void Start()
    {   
        konpemo = GetComponentInParent<Konpemo>();
        agent = GetComponentInParent<NavMeshAgent>();

        enemyLayerMask = LayerMask.GetMask("Blue");

        kingManager = GameObject.Find("KingManager").GetComponent<KingManager>();

        currentState = IAIdleState;
        currentState.EnterState(this);
    }

    void Update()
    {
        agent.speed = konpemo.speed.Value;
        currentState.UpdateState(this);
    }

    public void SwitchState(IABaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }

    public Konpemo GetClosestTarget(float rangeAtk, LayerMask konpemoTargetLayerMask) // Renvoie le GameObject le plus proche a attaquer
    {
        Collider[] unitsColliders = Physics.OverlapSphere(this.gameObject.transform.position, rangeAtk, konpemoTargetLayerMask);
        if (unitsColliders.Length > 0)
        {
            GameObject minDistGO = unitsColliders[0].gameObject;
            Vector3 TargetDist = minDistGO.transform.position - this.gameObject.transform.position;
            foreach (Collider unitCollider in unitsColliders)
            {
                if (!invisbleKonpemos.Contains(unitCollider.GetComponent<Konpemo>()))
                {
                    // Trouve la cible la plus proche a partir des transforms
                    Vector3 newTargetDist = unitCollider.transform.position - this.gameObject.transform.position;
                    if (newTargetDist.magnitude <= TargetDist.magnitude)
                    {
                        minDistGO = unitCollider.gameObject;
                        TargetDist = minDistGO.transform.position - this.gameObject.transform.position;
                    }
                }
            }
            return minDistGO.GetComponent<Konpemo>();
        }
        else
        {
            return null;
        }
    }


    public Konpemo CheckTauntAndKing(float rangeView)
    {
        //code optimisé au début je faisais un overlapSphere
        if (taunterKonpemos != null)
        {
            foreach (Konpemo taunterKonpemo in taunterKonpemos)
            {
                if ((taunterKonpemo.transform.position - this.gameObject.transform.position).magnitude <= rangeView)
                {
                    return taunterKonpemo;
                }
            }
            return null;
        }
		
        else if (king != null)
        {
            if ((king.transform.position - this.gameObject.transform.position).magnitude <= rangeView)
            {
                return king;
            }
            return null;
        }
        return null;
    }

}
