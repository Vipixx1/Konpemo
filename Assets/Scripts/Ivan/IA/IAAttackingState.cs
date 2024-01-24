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
            ia.target = visibleKingOrTaunt;
            taunted = true;
            ia.SwitchState(ia.IAMovingState);
        }
        if ((ia.target.transform.position - ia.transform.position).magnitude >= ia.konpemo.rangeAttack.Value && !ia.invisbleKonpemos.Contains(ia.target)) //cible hors de portee d'atk et pas invisble

        {
            ia.SwitchState(ia.IAMovingState);
        }
        else if (ia.konpemo.canAttack)
        {
            if (ia.target.isActiveAndEnabled && !ia.invisbleKonpemos.Contains(ia.target))
            {
                timeBetweenAttack = 1 / ia.konpemo.attackSpeed.Value;
                ia.konpemo.SetTarget(ia.target);
                ia.konpemo.animator.SetTrigger("Attack");
                ia.StartCoroutine(AttackCooldown(timeBetweenAttack, ia));
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
        ia.konpemo.canAttack = false;
        yield return new WaitForSeconds(timeToWait);
        ia.konpemo.canAttack = true;
    }
    public override void OnCollisionEnter(IAStateManager ia)
    {

    }
}
