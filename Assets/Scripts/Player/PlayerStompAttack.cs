using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStompAttack : PlayerBaseState
{
    public bool _allowUpdate;

    public override void EnterState(PlayerStateManager playerStateManager)
    {
        base.EnterState(playerStateManager);
        _playerStateManager.Animator.SetInteger("State", (int)GameEnums.EPlayerState.stompAttack);
        Debug.Log("tao la S Attack");
    }

    public override void ExitState()
    {
        _allowUpdate = false;
    }

    public override void UpdateState()
    {
        if (_allowUpdate)
        {
            if (_playerStateManager.DirX != 0 && _playerStateManager.DetectedGround)
                _playerStateManager.ChangeState(_playerStateManager.GetWalkState());
            else if (_playerStateManager.DirX == 0 && _playerStateManager.DetectedGround)
                _playerStateManager.ChangeState(_playerStateManager.GetIdleState());
            else if (Input.GetKeyDown(KeyCode.J) && _playerStateManager.CanThrowHat)
                _playerStateManager.ChangeState(_playerStateManager.GetHatAttack());
        }
    }

    public override void FixedUpdateState()
    {
    }
}
