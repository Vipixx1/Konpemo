using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CharAtkState : CharBaseState
{
    private bool canAttack;
    private float timeBetweenAttack;
    public override void EnterState(CharStateManager csm)
    {
        canAttack = true;
    }
    public override void UpdateState(CharStateManager csm)
    {
        if ((csm.cibleKonpemo.transform.position - csm.transform.position).magnitude >= csm.konpemo.rangeAttack.Value) //cible hors de portee d'atk
        {
            csm.SwitchState(csm.charAtkMovState);
        }
        else if (canAttack)
        {
            timeBetweenAttack = 1 / csm.konpemo.attackSpeed.Value;
            csm.konpemo.SetTarget(csm.cibleKonpemo);
            csm.konpemo.Attack();
            csm.StartCoroutine(AttackCooldown(timeBetweenAttack));
            Debug.Log("ATK");
        }
        else
        {
            //Debug.Log(canAttack);
        }
    }
    public IEnumerator AttackCooldown(float timeToWait)
    {
        canAttack = false;
        yield return new WaitForSeconds(timeToWait);
        canAttack = true;
    }
    public override void OnCollisionEnter(CharStateManager csm)
    {

    }
}
