using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class IAPatrollingState: IABaseState
{
    public List<Vector3> patrolBalises = new();
    private int baliseIndex;
    private readonly int baliseDetectionLimit = 1;
    public override void EnterState(IAStateManager ia)
    {
        
    }
    public override void UpdateState(IAStateManager ia)
    {
        //Debug.Log("IDLE");

        if (ia.target = ia.CheckTauntAndKing(ia.konpemo.rangeView.Value))
        {
            //Debug.Log("Je follow le ROI ou le taunt");

            ia.SwitchState(ia.IAMovingState);
        }
        else if (ia.target = ia.GetClosestTarget(ia.konpemo.rangeView.Value, ia.enemyLayerMask))
        {
            ia.SwitchState(ia.IAMovingState);
        }
        else if ((ia.transform.position - patrolBalises[baliseIndex]).magnitude <= baliseDetectionLimit)  //Si on est assez proche de la balise
        {
            if(patrolBalises.Count-1 > baliseIndex)
            {
                baliseIndex++;
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
