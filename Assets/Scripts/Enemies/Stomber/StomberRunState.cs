using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StomberRunState : EnemiesWalkState
{
    public StomberRunState(EnemiesStateManager currentContext, EnemiesStateFactory currentState) : base(currentContext, currentState)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        Debug.Log("Stomber Run");
    }

    public override void UpdateState()
    {
        enemy.Rb.velocity = new Vector2(2* enemy.WalkSpeed * enemy.RaycastDirX , enemy.Rb.velocity.y);

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
