using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharStateManager : MonoBehaviour
{
    [SerializeField]
    private float agentSpeed = 5;
    [SerializeField]
    public float porteeAtk = 3;
    [SerializeField]
    public float porteeVision = 50;

    public NavMeshAgent agent;
    public Vector3 destination;
    public GameObject cibleKonpemo;

    CharBaseState currentState;
    public CharIdleState charIdleState = new CharIdleState();
    public CharAtkState charAtkState = new CharAtkState();
    public CharMovingState charMovingState = new CharMovingState();
    public CharAtkMovState charAtkMovState = new CharAtkMovState();


    void Start()
    {
        agent.speed = agentSpeed;
        currentState = charIdleState;
        currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(CharBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }
}
