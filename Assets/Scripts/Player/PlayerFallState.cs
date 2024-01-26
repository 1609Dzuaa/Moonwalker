using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager playerStateManager)
    {
        base.EnterState(playerStateManager);
        Debug.Log("tao la Fall");
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void UpdateState()
    {
        if (Input.GetKeyDown(KeyCode.E))
            _playerStateManager.ChangeState(_playerStateManager.GetHatAttack());
        else if (_playerStateManager.DirX != 0 && _playerStateManager.DetectedGround)
            _playerStateManager.ChangeState(_playerStateManager.GetWalkState());
        else if (_playerStateManager.DirX == 0 && _playerStateManager.DetectedGround)
            _playerStateManager.ChangeState(_playerStateManager.GetIdleState());
    }

    public override void FixedUpdateState()
    {
        if (_playerStateManager.DirX != 0)
            _playerStateManager.Rigidbody2D.velocity = new Vector2(_playerStateManager.DirX * _playerStateManager.MovementSpeed, _playerStateManager.Rigidbody2D.velocity.y);
    }
}
