using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CharAtkState : CharBaseState
{
    public override void EnterState(CharStateManager csm)
    {

    }
    public override void UpdateState(CharStateManager csm)
    {
        /*if (ia.etat_cible) //cible est morte
        {
            ia.cible = null;
            ia.SwitchState(ia.IAIdleState);
        }*/

        if ((csm.cibleKonpemo.transform.position - csm.transform.position).magnitude >= csm.porteeAtk) //cible hors de portee d'atk
        {
            csm.SwitchState(csm.charAtkMovState);
        }
        else
        {
            //Debug.Log("DEGAT DEGAT"); //deal damage
            csm.konpemo.SetTarget(csm.cibleKonpemo);
            csm.konpemo.Attack();

        }
    }
    public override void OnCollisionEnter(CharStateManager csm)
    {

    }
}
