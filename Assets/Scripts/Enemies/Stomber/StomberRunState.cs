using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StomberRunState : EnemiesWalkState
{
    public StomberRunState(EnemiesStateManager currentContext, EnemiesStateFactory currentState) : base(currentContext, currentState)
    {
    }

    private bool _called = false;
    private IEnumerator enumerator;

    public override void EnterState()
    {
        base.EnterState();
        Debug.Log("Stomber Run");
        _called = false;
        enumerator = SwitchToIdleState();
    }

    public override void UpdateState()
    {
        CheckSwitchState();
        enemy.Rb.velocity = new Vector2(2* enemy.WalkSpeed * enemy.RaycastDirX , enemy.Rb.velocity.y);
        if(!enemy.SeePlayer && !_called)
        {
            _called = true;
            enumerator = SwitchToIdleState();
            enemy.StartCoroutine(enumerator);
        }
    }

    public override void CheckSwitchState()
    {
        base.CheckSwitchState();
        if(enemy.SeeGround)
        {
            enemy.StopCoroutine(enumerator);
            enumerator = null;
            SwitchState(factory.StomberAttack());
        }
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    private IEnumerator SwitchToIdleState()
    {
        yield return new WaitForSeconds(1.5f);
        SwitchState(factory.StomberIdle());
    }
}
