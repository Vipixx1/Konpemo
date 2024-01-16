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
            csm.SwitchState(csm.charAtkState);
        }
        else if (distanceToCible >= csm.konpemo.rangeView.Value)
        {
            //pas de stop de l'agent, ça fait plus réaliste
            csm.SwitchState(csm.charIdleState);
        }
        else  //pour l'instant les ia poursuivent jusqu'à la mort
        {
            csm.agent.SetDestination(csm.cibleKonpemo.transform.position);
        }
    }
    public override void OnCollisionEnter(CharStateManager csm)
    {

    }
}

