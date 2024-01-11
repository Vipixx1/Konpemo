using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IABaseState
{
    public abstract void EnterState(IAStateManager ia);
    public abstract void UpdateState(IAStateManager ia);
    public abstract void OnCollisionEnter(IAStateManager ia);
}
