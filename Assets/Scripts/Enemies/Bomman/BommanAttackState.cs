using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BommanAttackState : EnemiesAttackState
{
    private GameObject prefabtEgg;
    public BommanAttackState(EnemiesStateManager currentContext, EnemiesStateFactory currentState) : base(currentContext, currentState)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        Debug.Log("Bom nổ");
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
        yield return new WaitForSeconds(1f);
        SwitchState(factory.BommanWalk());
    }

    private void Attack()
    {
        ObjectPooler.Instant.GetPoolObject("Egg", enemy.transform.position, Quaternion.identity);
    }
}
