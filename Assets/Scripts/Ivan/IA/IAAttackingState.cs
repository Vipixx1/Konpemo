using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class IAAttackingState : IABaseState
{
    public override void EnterState(IAStateManager ia)
    {

    }
    public override void UpdateState(IAStateManager ia)
    {
        if (ia.etat_cible) //cible est morte
        {
            ia.cible = null;
            ia.SwitchState(ia.IAIdleState);
        }
        else if ((ia.cible.transform.position - ia.transform.position).magnitude >= ia.porteeAtk) //cible hors de portee d'atk
        {
            ia.SwitchState(ia.IAMovingState);
        }
        else
        {
            ia.konpemo.SetTarget(ia.cible);
            ia.konpemo.Attack();
            Debug.Log("Deal Damages");//deal damage
        }
    }
    public override void OnCollisionEnter(IAStateManager ia)
    {

    }
}
