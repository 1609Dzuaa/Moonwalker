using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StomberWalkState : EnemiesWalkState
{
    public StomberWalkState(EnemiesStateManager currentContext, EnemiesStateFactory currentState) : base(currentContext, currentState)
    {
    }

    IEnumerator enumerator;

    public override void EnterState()
    {
        base.EnterState();
        Debug.Log("Stomber Walk");
        enumerator = SwitchToIdleState();
        enemy.StartCoroutine(enumerator);
    }

    public override void UpdateState()
    {
        base.UpdateState();
    }

    public override void CheckSwitchState()
    {
        base.CheckSwitchState();
        if (enemy.SeePlayer)
        {
            enemy.StopCoroutine(enumerator);
            enumerator = null;
            SwitchState(factory.StomberRun());
        }
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    private IEnumerator SwitchToIdleState()
    {
        yield return new WaitForSeconds(2f);
        Debug.Log("Switch to idle");
        SwitchState(factory.StomberIdle());
    }
}
