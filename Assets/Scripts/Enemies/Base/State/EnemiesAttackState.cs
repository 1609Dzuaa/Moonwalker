using UnityEngine;

public class EnemiesAttackState : EnemiesBaseState
{
    public EnemiesAttackState(EnemiesStateManager currentContext, EnemiesStateFactory currentState) : base(currentContext, currentState)
    {
    }

    public override void CheckSwitchState()
    {

    }

    public override void EnterState()
    {
        //Debug.Log("Hello from Attack State");
        enemy.Anim.SetInteger("State", (int)GameEnums.EEnemiesState.attack);
    }

    public override void ExitState()
    {

    }

    public override void UpdateState()
    {
        CheckSwitchState();
    }
}