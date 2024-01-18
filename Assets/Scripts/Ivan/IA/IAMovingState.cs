using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class IAMovingState : IABaseState
{
    private float distanceToCible;
    private Konpemo visibleKing;
    public override void EnterState(IAStateManager ia)
    {

    }
    public override void UpdateState(IAStateManager ia)
    {
        distanceToCible = (ia.cible.transform.position - ia.transform.position).magnitude;
        visibleKing = ia.CheckKing(ia.konpemo.rangeView.Value);
        if (visibleKing != null)
        {
            ia.cible = visibleKing;
        }
        if (distanceToCible <= ia.konpemo.rangeAttack.Value) //cible a portee d'atk
        {
            ia.agent.SetDestination(ia.transform.position);
            ia.SwitchState(ia.IAAttackingState);
        }
        else if (distanceToCible >= ia.konpemo.rangeView.Value)  // cible hors de portee de vision
        {
            ia.SwitchState(ia.IAIdleState);
        }
        else  //cible a portee de vision
        {
            ia.agent.SetDestination(ia.cible.transform.position);
        }
    }
    public override void OnCollisionEnter(IAStateManager ia)
    {

    }
}
