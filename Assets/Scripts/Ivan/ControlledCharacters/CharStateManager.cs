using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharStateManager : MonoBehaviour
{
    public NavMeshAgent agent;
    public Konpemo konpemo;

    CharBaseState currentState;
    public CharIdleState charIdleState = new CharIdleState();
    public CharAtkState charAtkState = new CharAtkState();
    public CharMovingState charMovingState = new CharMovingState();
    public CharAtkMovState charAtkMovState = new CharAtkMovState();

    public Vector3 destination;
    public Konpemo cibleKonpemo;


    void Start()
    {
        konpemo = agent.GetComponent<Konpemo>();
        agent = GetComponent<NavMeshAgent>();

        agent.speed = konpemo.speed.Value;

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
}
