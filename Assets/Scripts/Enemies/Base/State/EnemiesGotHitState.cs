using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEditor.Callbacks;
using UnityEngine;

public class EnemiesGotHitState : EnemiesBaseState
{
    public EnemiesGotHitState(EnemiesStateManager currentContext, EnemiesStateFactory currentState) : base(currentContext, currentState)
    {
    }

    public override void CheckSwitchState()
    {

    }

    public override void EnterState()
    {
        enemy.Health -=1;
        if (enemy.Health < 0)
        {
            enemy.Col.isTrigger = true;
            enemy.Rb.velocity = new UnityEngine.Vector2(0f, 0f);
            enemy.Anim.SetTrigger("Death");
            enemy.EnemiesDeath();
        }
        else
        {
            enemy.Anim.SetInteger("State", (int)GameEnums.EEnemiesState.gothit);
        }
    }

    public override void ExitState()
    {

    }

    public override void UpdateState()
    {
        CheckSwitchState();
    }
}