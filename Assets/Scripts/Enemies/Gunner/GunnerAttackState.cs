using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunnerAttackState : EnemiesAttackState
{
    public GunnerAttackState(EnemiesStateManager currentContext, EnemiesStateFactory currentState) : base(currentContext, currentState)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
    }

    public override void UpdateState()
    {
        base.UpdateState();
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