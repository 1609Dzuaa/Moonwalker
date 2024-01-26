using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BommanIdleState : EnemiesIdleState
{
    public BommanIdleState(EnemiesStateManager currentContext, EnemiesStateFactory currentState) : base(currentContext, currentState)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        Debug.Log("Chào tao là bom");
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
