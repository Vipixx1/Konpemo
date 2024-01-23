using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class IAMovingState : IABaseState
{
    private float distanceToCible;
    private Konpemo visibleKingOrTaunt;
    public override void EnterState(IAStateManager ia)
    {

    }
    public override void UpdateState(IAStateManager ia)
    {

        distanceToCible = (ia.target.transform.position - ia.transform.position).magnitude;
        visibleKingOrTaunt = ia.CheckTauntAndKing(ia.konpemo.rangeView.Value);
        if (visibleKingOrTaunt != null)
        {
            ia.target = visibleKingOrTaunt;
        }
        if (ia.target.isActiveAndEnabled)
        {
            if (distanceToCible <= ia.konpemo.rangeAttack.Value && !ia.invisbleKonpemos.Contains(ia.target)) //cible a portee d'atk et pas invisible
            {
                ia.agent.SetDestination(ia.transform.position);
                ia.SwitchState(ia.IAAttackingState);
            }
            else if (distanceToCible >= ia.konpemo.rangeView.Value)  // cible hors de portee de vision et hors de portee d'atk
            {
                ia.SwitchState(ia.IAIdleState);
            }
            else if(!ia.invisbleKonpemos.Contains(ia.target)) //cible a portee de vision et pas invisble
            {
                ia.agent.SetDestination(ia.target.transform.position);
            }
        }
        else
        {
            ia.SwitchState(ia.IAIdleState);
        }

    }
	
    public override void OnCollisionEnter(IAStateManager ia)
    {

    }
}
