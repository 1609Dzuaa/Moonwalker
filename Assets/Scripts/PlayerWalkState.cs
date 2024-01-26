using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalkState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager playerStateManager)
    {
        base.EnterState(playerStateManager);
        Debug.Log("tao la walk");
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void UpdateState()
    {
        if(_playerStateManager.DirX == 0)
            _playerStateManager.ChangeState(_playerStateManager.GetIdleState());
        else if (Input.GetButtonDown("Jump") && _playerStateManager.DetectedGround)
            _playerStateManager.ChangeState(_playerStateManager.GetJumpState());
    }

    public override void FixedUpdateState()
    {
        _playerStateManager.Rigidbody2D.velocity = new Vector2(_playerStateManager.DirX * _playerStateManager.MovementSpeed, _playerStateManager.Rigidbody2D.velocity.y);
    }
}
