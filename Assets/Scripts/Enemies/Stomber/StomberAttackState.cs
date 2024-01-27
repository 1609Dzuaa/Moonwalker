using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StomberAttackState : EnemiesAttackState
{
    public StomberAttackState(EnemiesStateManager currentContext, EnemiesStateFactory currentState) : base(currentContext, currentState)
    {
    }
    private IEnumerator enumerator;

    public override void EnterState()
    {
        base.EnterState();
        Debug.Log("xieen");

        enumerator = SwitchToIdleState();
        enemy.StartCoroutine(enumerator);
    }

    public override void UpdateState()
    {
        base.UpdateState();
        Debug.Log("xieen");
        enemy.Rb.velocity = new Vector2(enemy.WalkSpeed * enemy.RaycastDirX , enemy.Rb.velocity.y);
    }

    public override void CheckSwitchState()
    {
        base.CheckSwitchState();
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    private IEnumerator SwitchToIdleState()
    {
        yield return new WaitForSeconds(1f);
        SwitchState(factory.StomberIdle());
    }
}
