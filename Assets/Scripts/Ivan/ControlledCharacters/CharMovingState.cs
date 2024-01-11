using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CharMovingState : CharBaseState
{
    [SerializeField]
    private float limitToDestinationReached = 1;
    public override void EnterState(CharStateManager csm)
    {
        csm.agent.SetDestination(csm.destination);
    }
    public override void UpdateState(CharStateManager csm)
    {
        if ((csm.destination - csm.agent.transform.position).magnitude <= limitToDestinationReached)
        {
            csm.SwitchState(csm.charIdleState);
        }
    }
    public override void OnCollisionEnter(CharStateManager csm)
    {

    }
}
