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
        enemy.Rb.velocity = new Vector2(0f, enemy.Rb.velocity.y);
        Debug.Log("Bắn bỏ mọe");
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
