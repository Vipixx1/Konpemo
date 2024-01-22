using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class IAAttackingState : IABaseState
{
    private float timeBetweenAttack;
    private Konpemo visibleKingOrTaunt;
    private bool taunted = false;
    public override void EnterState(IAStateManager ia)
    {

    }
    public override void UpdateState(IAStateManager ia)
    {
        visibleKingOrTaunt = ia.CheckTauntAndKing(ia.konpemo.rangeView.Value);
        if (visibleKingOrTaunt == null)
        {
            taunted = false;
        }
        else if (visibleKingOrTaunt != null && !taunted)
        {
            ia.cible = visibleKingOrTaunt;
            taunted = true;
            ia.SwitchState(ia.IAMovingState);
        }
        if ((ia.cible.transform.position - ia.transform.position).magnitude >= ia.konpemo.rangeAttack.Value) //cible hors de portee d'atk
        {
            ia.SwitchState(ia.IAMovingState);
        }
        else if (ia.konpemo.canAttack)
        {
            if (ia.cible.isActiveAndEnabled)
            {
                timeBetweenAttack = 1 / ia.konpemo.attackSpeed.Value;
                ia.konpemo.SetTarget(ia.cible);
                ia.konpemo.Attack();
                ia.StartCoroutine(AttackCooldown(timeBetweenAttack, ia));
                Debug.Log("Deal Damages");
            }
            else
            {
                ia.SwitchState(ia.IAIdleState);
            }
        }
        else
        {
            //Debug.Log("pas d'attaques");
        }
    }
    public IEnumerator AttackCooldown(float timeToWait, IAStateManager ia)
    {
        ia.konpemo.canAttack=false;
        yield return new WaitForSeconds(timeToWait);
        ia.konpemo.canAttack = true;
    }
    public override void OnCollisionEnter(IAStateManager ia)
    {

    }
}
