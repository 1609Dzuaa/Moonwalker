using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager playerStateManager)
    {
        base.EnterState(playerStateManager);
        _playerStateManager.Animator.SetInteger("State", (int)GameEnums.EPlayerState.idle);
        //Debug.Log("tao la idle");
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void UpdateState()
    {
        if (_playerStateManager.DirX != 0)
            _playerStateManager.ChangeState(_playerStateManager.GetWalkState());
        else if (Input.GetButtonDown("Jump") && _playerStateManager.DetectedGround)
            _playerStateManager.ChangeState(_playerStateManager.GetJumpState());
        else if (Input.GetKeyDown(KeyCode.J) && _playerStateManager.CanThrowHat)
            _playerStateManager.ChangeState(_playerStateManager.GetHatAttack());
        else if (Input.GetKeyDown(KeyCode.K))
            _playerStateManager.ChangeState(_playerStateManager.GetStompAttack());
    }

    public override void FixedUpdateState()
    {
        base.FixedUpdateState();
    }
}
