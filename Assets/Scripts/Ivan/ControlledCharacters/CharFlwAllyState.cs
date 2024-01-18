using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharFlwAllyState : CharBaseState
{
    private bool ableToMove = true;
    private float tooCloseLimit = 3;
    public override void EnterState(CharStateManager csm)
    {
        
    }
    public override void UpdateState(CharStateManager csm)
    {
        if((csm.gameObject.transform.position - csm.cibleKonpemo.transform.position).magnitude <= tooCloseLimit)
        {
            ableToMove = false;
            csm.agent.SetDestination(csm.gameObject.transform.position);
        }
        else
        {
            ableToMove = true;
        }
        if(ableToMove)
        {
            csm.agent.SetDestination(csm.cibleKonpemo.transform.position);
        }
    }
}