using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager playerStateManager)
    {
        base.EnterState(playerStateManager);
        _playerStateManager.Animator.SetInteger("State", (int)GameEnums.EPlayerState.jump);
        Jump();
        //Debug.Log("tao la Jump");
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void UpdateState()
    {
        if (_playerStateManager.Rigidbody2D.velocity.y < -0.1f)
            _playerStateManager.ChangeState(_playerStateManager.GetFallState());
        else if (Input.GetKeyDown(KeyCode.E) && _playerStateManager.CanThrowHat)
            _playerStateManager.ChangeState(_playerStateManager.GetHatAttack());
    }

    public override void FixedUpdateState()
    {
        if (_playerStateManager.DirX != 0)
            _playerStateManager.Rigidbody2D.velocity = new Vector2(_playerStateManager.MovementSpeed * _playerStateManager.DirX, _playerStateManager.Rigidbody2D.velocity.y);
    }

    private void Jump()
    {
        _playerStateManager.Rigidbody2D.AddForce(new Vector2(0f, _playerStateManager.JumpForce));
    }
}
