using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class IAAttackingState : IABaseState
{
    private bool canAttack;
    private float timeBetweenAttack;
    public override void EnterState(IAStateManager ia)
    {
        canAttack = true;
    }
    public override void UpdateState(IAStateManager ia)
    {
        if ((ia.cible.transform.position - ia.transform.position).magnitude >= ia.konpemo.rangeAttack.Value) //cible hors de portee d'atk
        {
            ia.SwitchState(ia.IAMovingState);
        }
        else if (canAttack)
        {
            if (ia.cible.isActiveAndEnabled)
            {
                timeBetweenAttack = 1 / ia.konpemo.attackSpeed.Value;
                ia.konpemo.SetTarget(ia.cible);
                ia.konpemo.Attack();
                ia.StartCoroutine(AttackCooldown(timeBetweenAttack));
                //Debug.Log("Deal Damages");
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
    public IEnumerator AttackCooldown(float timeToWait)
    {
        canAttack=false;
        yield return new WaitForSeconds(timeToWait);
        canAttack = true;
    }
    public override void OnCollisionEnter(IAStateManager ia)
    {

    }
}
