using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGotHitState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager playerStateManager)
    {
        base.EnterState(playerStateManager);
        _playerStateManager.Animator.SetInteger("State", (int)GameEnums.EPlayerState.gotHit);
    }

    public override void ExitState()
    {
    }

    public override void UpdateState()
    {
      
    }

    public override void FixedUpdateState()
    {
        _playerStateManager.Rigidbody2D.velocity = Vector2.zero;
    }
}
