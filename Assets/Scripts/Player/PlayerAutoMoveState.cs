using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAutoMoveState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager playerStateManager)
    {
        base.EnterState(playerStateManager);
        _playerStateManager.Animator.SetInteger("State", (int)GameEnums.EPlayerState.walk);
        CameraController.Instant.PlayerRef = null;
        UIManager.Instant.StartCoroutine(UIManager.Instant.PopUpWinPanel());
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void UpdateState()
    {
       
    }

    public override void FixedUpdateState()
    {
        _playerStateManager.Rigidbody2D.velocity = new Vector2(_playerStateManager.MovementSpeed, _playerStateManager.Rigidbody2D.velocity.y);
    }
}
