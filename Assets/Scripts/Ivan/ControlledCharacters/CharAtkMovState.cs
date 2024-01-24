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
        distanceToCible = (csm.targetKonpemo.transform.position - csm.transform.position).magnitude;

        // Si la cible est dans la portee d'attaque (RangeAttack) :
        if (distanceToCible <= csm.konpemo.rangeAttack.Value) 
        {
            csm.agent.SetDestination(csm.transform.position);
            csm.SwitchState(csm.charAtkState);
        }

        // Si la cible est hors de la portee d'attaque , mais dans la portee de vision (RangeVision) :
        else
        {
            csm.agent.SetDestination(csm.targetKonpemo.transform.position);
        }

        // Si la cible est hors de portee d'attaque et hors de portee vision :
        // A IMPLEMENTER SI ON RAJOUTE UN FOG OF WAR...
        /*else if (distanceToCible >= csm.konpemo.rangeView.Value) 
        {
            csm.destination = csm.cibleKonpemo.transform.position;
            csm.SwitchState(csm.charMovingState);
        }
*/

    }
}

