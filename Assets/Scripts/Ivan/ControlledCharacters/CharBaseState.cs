using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharBaseState
{
    public abstract void EnterState(CharStateManager ia);
    public abstract void UpdateState(CharStateManager ia);
    public abstract void OnCollisionEnter(CharStateManager ia);
}
