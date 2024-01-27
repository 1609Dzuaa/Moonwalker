using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerBaseState
{
    public bool _allowUpdate;

    public override void EnterState(PlayerStateManager playerStateManager)
    {
        base.EnterState(playerStateManager);
        _playerStateManager.Animator.SetInteger("State", (int)GameEnums.EPlayerState.jump);
        Jump();
        //Debug.Log("tao la Jump");
    }

    public override void ExitState()
    {
        _allowUpdate = false;
    }

    public override void UpdateState()
    {
        if (_allowUpdate)
            if (_playerStateManager.DirX != 0 && _playerStateManager.DetectedGround)
                _playerStateManager.ChangeState(_playerStateManager.GetWalkState());
            else if (_playerStateManager.DirX == 0 && _playerStateManager.DetectedGround)
                _playerStateManager.ChangeState(_playerStateManager.GetIdleState());
    }

    public override void FixedUpdateState()
    {
        if (_playerStateManager.DirX != 0)
            _playerStateManager.Rigidbody2D.velocity = new Vector2(_playerStateManager.MovementSpeed * _playerStateManager.DirX * -1, _playerStateManager.Rigidbody2D.velocity.y);
    }

    private void Jump()
    {
        _playerStateManager.Rigidbody2D.AddForce(new Vector2(0f, _playerStateManager.JumpForce));
    }
}
