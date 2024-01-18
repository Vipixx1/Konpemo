using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class IAPatrollingState: IABaseState
{
    public List<Vector3> patrolBalises = new();
    private int baliseIndex;
    private int baliseDetectionLimit = 1;
    public override void EnterState(IAStateManager ia)
    {
        
    }
    public override void UpdateState(IAStateManager ia)
    {
        //Debug.Log("IDLE");
        if (ia.cible = ia.CheckKing(ia.konpemo.rangeView.Value))
        {
            //Debug.Log("Je follow le ROI");
            ia.SwitchState(ia.IAMovingState);
        }
        else if (ia.cible = ia.CibleLaPlusProche(ia.konpemo.rangeView.Value, ia.masqueEnnemi))
        {
            ia.SwitchState(ia.IAMovingState);
        }
        else if ((ia.transform.position - patrolBalises[baliseIndex]).magnitude <= baliseDetectionLimit)  //Si on est assez proche de la balise
        {
            if(patrolBalises.Count-1 > baliseIndex)
            {
                baliseIndex = baliseIndex + 1;
            }
            else
            {
                baliseIndex = 0;
            }
            ia.agent.SetDestination(patrolBalises[baliseIndex]);
        }
        else
        {
            ia.agent.SetDestination(patrolBalises[baliseIndex]);
        }
    }
    public override void OnCollisionEnter(IAStateManager ia)
    {

    }
}
