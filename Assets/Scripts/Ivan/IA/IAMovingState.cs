using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class IAMovingState : IABaseState
{
    private float distanceToCible;
    public override void EnterState(IAStateManager ia)
    {

    }
    public override void UpdateState(IAStateManager ia)
    {
        distanceToCible = (ia.cible.transform.position - ia.transform.position).magnitude;
        if (distanceToCible <= ia.konpemo.rangeAttack.Value) //cible a portee d'atk
        {
            Debug.Log((ia.cible.transform.position - ia.transform.position).magnitude);
            ia.SwitchState(ia.IAAttackingState);
        }
        else if (distanceToCible >= ia.konpemo.rangeView.Value)
        {
            //pas de stop de l'agent, ça fait plus réaliste
            ia.SwitchState(ia.IAIdleState);
        }
        else  //pour l'instant les ia poursuivent jusqu'à la mort
        {
            ia.agent.SetDestination(ia.cible.transform.position);
        }
    }
    public override void OnCollisionEnter(IAStateManager ia)
    {

    }
}
