using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CharAtkMovState : CharBaseState
{
    private float distanceToCible;
    public override void EnterState(CharStateManager csm)
    {

    }
    public override void UpdateState(CharStateManager csm)
    {
        distanceToCible = (csm.cibleKonpemo.transform.position - csm.transform.position).magnitude;
        if (distanceToCible <= csm.konpemo.rangeAttack.Value) //cible a portee d'atk
        {
            csm.agent.SetDestination(csm.transform.position);
            csm.SwitchState(csm.charAtkState);
        }
        else if (distanceToCible >= csm.konpemo.rangeView.Value) //cible hors de portee d'atk
        {
            csm.SwitchState(csm.charIdleState);
        }
        else  //cible dans la portee de vision
        {
            csm.agent.SetDestination(csm.cibleKonpemo.transform.position);
        }
    }
}

