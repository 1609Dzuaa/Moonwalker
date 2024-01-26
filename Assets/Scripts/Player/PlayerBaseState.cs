using UnityEngine;

public abstract class PlayerBaseState
{
    protected PlayerStateManager _playerStateManager;

    public virtual void EnterState(PlayerStateManager playerStateManager) { _playerStateManager = playerStateManager; }

    public virtual void ExitState() { }

    public virtual void UpdateState() { }

    public virtual void FixedUpdateState() { }
}
