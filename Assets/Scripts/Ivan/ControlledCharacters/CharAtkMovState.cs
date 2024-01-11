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
        /*if (csm.etat_cible) //cible est morte
        {
            ia.cible = null;
            ia.SwitchState(ia.IAIdleState);
        }*/
        if (distanceToCible <= csm.porteeAtk) //cible a portee d'atk
        {
            csm.SwitchState(csm.charAtkState);
        }
        else if (distanceToCible >= csm.porteeVision)
        {
            //pas de stop de l'agent, �a fait plus r�aliste
            csm.SwitchState(csm.charIdleState);
        }
        else  //pour l'instant les ia poursuivent jusqu'� la mort
        {
            csm.agent.SetDestination(csm.cibleKonpemo.transform.position);
        }
    }
    public override void OnCollisionEnter(CharStateManager csm)
    {

    }
}

