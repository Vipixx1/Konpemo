using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class IAIdleState : IABaseState
{
    public override void EnterState(IAStateManager ia)
    {

    }
    public override void UpdateState(IAStateManager ia)
    {
        if (ia.cible = ia.CheckKing(ia.porteeVision))
        {
            Debug.Log("Je follow le ROI");
            ia.SwitchState(ia.IAMovingState);
        }
        else if (ia.cible = ia.CibleLaPlusProche(ia.porteeVision, ia.masqueEnnemi))
        {
            //Debug.Log("Idle");
            ia.SwitchState(ia.IAMovingState);
        }
    }
    public override void OnCollisionEnter(IAStateManager ia)
    {

    }
}
