using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StomberIdleState : EnemiesIdleState
{
    public StomberIdleState(EnemiesStateManager currentContext, EnemiesStateFactory currentState) : base(currentContext, currentState)
    {
    }

    IEnumerator enumerator;

    public override void EnterState()
    {
        base.EnterState();
        enemy.FlipXObject();
        //Debug.Log("Stomber Idle");
        enumerator =  SwitchToWalkState();
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

    public IEnumerator SwitchToWalkState()
    {
        yield return new WaitForSeconds(1f);
        SwitchState(factory.StomberWalk());
    }
}
