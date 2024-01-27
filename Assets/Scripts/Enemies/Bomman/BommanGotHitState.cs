using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BommanGotHitState : EnemiesBaseState
{
    public BommanGotHitState(EnemiesStateManager currentContext, EnemiesStateFactory currentState) : base(currentContext, currentState)
    {
    }

    public override void EnterState()
    {
        
        Debug.Log("Gh Bom");
    }

    public override void UpdateState()
    {
        
    }

    public override void CheckSwitchState()
    {
        if (enemy.SeePlayer)
        {
            SwitchState(factory.BommanAttack());
        }
    }

    public override void ExitState()
    {
        
    }
}
