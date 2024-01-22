using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharStateManager : MonoBehaviour
{
    public NavMeshAgent agent;
    public Konpemo konpemo;
    public KingManager kingManager;
    public LayerMask allyUnitMask;

    CharBaseState currentState;
    public CharIdleState charIdleState = new();
    public CharAtkState charAtkState = new();
    public CharMovingState charMovingState = new();
    public CharAtkMovState charAtkMovState = new();
    public CharFlwAllyState charFlwAllyState = new();

    public Vector3 destination;
    public Konpemo cibleKonpemo;


    void Start()
    {
        konpemo = GetComponentInParent<Konpemo>();
        agent = GetComponentInParent<NavMeshAgent>();
        agent.speed = konpemo.speed.Value;

        kingManager = GameObject.Find("KingManager").GetComponent<KingManager>();
        
        allyUnitMask = LayerMask.GetMask("Blue");

        

        currentState = charIdleState;
        currentState.EnterState(this);
    }

    void Update()
    {
        agent.speed = konpemo.speed.Value;
        currentState.UpdateState(this);
    }

    public void SwitchState(CharBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }

    private void OnDrawGizmos()
    {
        if(agent != null)
        {
            Gizmos.DrawWireSphere(agent.destination, 1);
        }
    }
}
