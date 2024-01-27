using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StomberStateManager : EnemiesStateManager
{
    public override void Start()
    {
        CurrentState = State.StomberIdle();
        CurrentState.EnterState();
    }

    public override void GotHit()
    {
        CurrentState.ExitState();
        CurrentState = State.StomberGotHit();
        CurrentState.EnterState();
    }

    public void Attack()
    {
        if(SeeGround)
        {
            PlayerStateManager player = FindObjectOfType<PlayerStateManager>();
            player.ChangeState(player.GotHit);
        }
    }

}
