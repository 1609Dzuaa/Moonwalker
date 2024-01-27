using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalkState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager playerStateManager)
    {
        base.EnterState(playerStateManager);
        _playerStateManager.Animator.SetInteger("State", (int)GameEnums.EPlayerState.walk);
        //Debug.Log("tao la walk");
    }

    public override void ExitState()
    {

    }

    public override void UpdateState()
    {
        if(_playerStateManager.DirX == 0)
            _playerStateManager.ChangeState(_playerStateManager.GetIdleState());
        else if (Input.GetButtonDown("Jump") && _playerStateManager.DetectedGround)
            _playerStateManager.ChangeState(_playerStateManager.GetJumpState());
        else if (Input.GetKeyDown(KeyCode.J) && _playerStateManager.CanThrowHat)
            _playerStateManager.ChangeState(_playerStateManager.GetHatAttack());
        else if (Input.GetKeyDown(KeyCode.K))
            _playerStateManager.ChangeState(_playerStateManager.GetStompAttack());
    }

    public override void FixedUpdateState()
    {
        _playerStateManager.Rigidbody2D.velocity = new Vector2(_playerStateManager.DirX * -1 * _playerStateManager.MovementSpeed, _playerStateManager.Rigidbody2D.velocity.y);
    }
}
