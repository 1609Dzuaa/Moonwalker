using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BommanAttackState : EnemiesAttackState
{
    public BommanAttackState(EnemiesStateManager currentContext, EnemiesStateFactory currentState) : base(currentContext, currentState)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        Debug.Log("Bom nổ");
        enemy.Rb.velocity = new Vector2(0f, enemy.Rb.velocity.y);
        enemy.StartCoroutine(SwitchToWalkState());
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
    
    public IEnumerator SwitchToWalkState()
    {
        yield return new WaitForSeconds(2f);
        SwitchState(factory.BommanWalk());
    }
}
