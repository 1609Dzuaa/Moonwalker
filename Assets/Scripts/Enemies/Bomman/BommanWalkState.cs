using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BommanWalkState : EnemiesWalkState
{
    public BommanWalkState(EnemiesStateManager currentContext, EnemiesStateFactory currentState) : base(currentContext, currentState)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        Debug.Log("Bom đi bộ");
    }

    public override void UpdateState()
    {
        enemy.Rb.velocity = new Vector2(- enemy.WalkSpeed * enemy.RaycastDirX , enemy.Rb.velocity.y);
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
