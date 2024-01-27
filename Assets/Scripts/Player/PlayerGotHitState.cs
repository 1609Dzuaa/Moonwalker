using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGotHitState : PlayerBaseState
{
    public bool _allowUpdate;

    public override void EnterState(PlayerStateManager playerStateManager)
    {
        base.EnterState(playerStateManager);
        _playerStateManager.Animator.SetInteger("State", (int)GameEnums.EPlayerState.gotHit);
        _playerStateManager.Rigidbody2D.bodyType = RigidbodyType2D.Static;
        _playerStateManager.GetBoxCol2D().enabled = false;
        SoundsManager.Instant.PlaySFX(GameEnums.ESoundName.OuchSfx);
        Debug.Log("GotHit");
    }

    public override void ExitState()
    {
        _allowUpdate = false;
        _playerStateManager.Rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
        _playerStateManager.GetBoxCol2D().enabled = true;
    }

    public override void UpdateState()
    {
        if (_allowUpdate)
        {
            if (_playerStateManager.DirX != 0)
                _playerStateManager.ChangeState(_playerStateManager.GetWalkState());
            else if (_playerStateManager.DirX == 0)
                _playerStateManager.ChangeState(_playerStateManager.GetIdleState());
            else if (Input.GetButtonDown("Jump") && _playerStateManager.DetectedGround)
                _playerStateManager.ChangeState(_playerStateManager.GetJumpState());
            else if (Input.GetKeyDown(KeyCode.J) && _playerStateManager.CanThrowHat)
                _playerStateManager.ChangeState(_playerStateManager.GetHatAttack());
            else if (Input.GetKeyDown(KeyCode.K))
                _playerStateManager.ChangeState(_playerStateManager.GetStompAttack());
        }
    }

    public override void FixedUpdateState()
    {
    }
}
