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
    }
    public override void OnCollisionEnter(IAStateManager ia)
    {

    }
}
