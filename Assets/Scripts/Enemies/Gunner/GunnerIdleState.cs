using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunnerIdleState : EnemiesIdleState
{
    public GunnerIdleState(EnemiesStateManager currentContext, EnemiesStateFactory currentState) : base(currentContext, currentState)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
    }

    public override void UpdateState()
    {
        base.UpdateState();
        Debug.Log("Gunner Idle");
    }

    public override void CheckSwitchState()
    {
        base.CheckSwitchState();
        if(enemy.SeePlayer)
        {
            SwitchState(factory.GunnerWalk());
        }
    }

    public override void ExitState()
    {
        base.ExitState();
    }
}
