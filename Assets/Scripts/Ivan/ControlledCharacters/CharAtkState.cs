using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CharAtkState : CharBaseState
{
    private float timeBetweenAttack;
    public override void EnterState(CharStateManager csm)
    {
        //csm.agent.SetDestination(csm.transform.position);
    }
    public override void UpdateState(CharStateManager csm)
    {
        if ((csm.targetKonpemo.transform.position - csm.transform.position).magnitude >= csm.konpemo.rangeAttack.Value) //cible hors de portee d'atk
        {
            csm.SwitchState(csm.charAtkMovState);
        }
        else if (csm.konpemo.canAttack)
        {
            if (csm.targetKonpemo.isActiveAndEnabled)
            {
                if (csm.kingManager.GetKing()?.name != csm.konpemo.name)
                {
                    timeBetweenAttack = 1 / csm.konpemo.attackSpeed.Value;
                    csm.konpemo.SetTarget(csm.targetKonpemo);
                    csm.konpemo.animator.SetTrigger("Attack");
                    csm.StartCoroutine(AttackCooldown(timeBetweenAttack, csm));
                    //Debug.Log("ATK");
                }
            }
        }

        else
        {
            //Debug.Log(canAttack);
        }
    }
    public IEnumerator AttackCooldown(float timeToWait, CharStateManager csm)
    {
        csm.konpemo.canAttack = false;
        yield return new WaitForSeconds(timeToWait);
        csm.konpemo.canAttack = true;
    }
}
