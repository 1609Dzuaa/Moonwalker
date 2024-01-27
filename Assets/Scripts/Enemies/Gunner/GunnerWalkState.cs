using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunnerWalkState : EnemiesWalkState
{
    public GunnerWalkState(EnemiesStateManager currentContext, EnemiesStateFactory currentState) : base(currentContext, currentState)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        enemy.StartCoroutine(SwitchToAttackState());
    }

    public override void UpdateState()
    {
        CheckSwitchState();
        float dirX = Input.GetAxisRaw("Horizontal");
        enemy.Rb.velocity = new Vector2(- enemy.WalkSpeed * dirX , enemy.Rb.velocity.y);
    }

    public override void CheckSwitchState()
    {
        base.CheckSwitchState();
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    private IEnumerator SwitchToAttackState()
    {
        yield return new WaitForSeconds(enemy.DelayTimeShoot);
        SwitchState(factory.GunnerAttack());
    }
}
