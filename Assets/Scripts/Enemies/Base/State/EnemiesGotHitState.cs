using System.Collections;
using System.Collections.Generic;
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
            enemy.Anim.SetTrigger("Death");
            enemy.Rb.AddForce(Vector2.up * 3f, ForceMode2D.Impulse);
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
        enemy.Rb.velocity = new Vector2(enemy.WalkSpeed * enemy.RaycastDirX , enemy.Rb.velocity.y); 
    }
}