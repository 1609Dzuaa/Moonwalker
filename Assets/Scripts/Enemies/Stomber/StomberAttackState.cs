using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StomberAttackState : EnemiesAttackState
{
    public StomberAttackState(EnemiesStateManager currentContext, EnemiesStateFactory currentState) : base(currentContext, currentState)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        Debug.Log("xieen");
    }

    public override void UpdateState()
    {
        base.UpdateState();
        Debug.Log("xieen");
    }

    public override void CheckSwitchState()
    {
        base.CheckSwitchState();
    }

    public override void ExitState()
    {
        base.ExitState();
    }
}
