using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GunnerStateManager : EnemiesStateManager
{
    [SerializeField] private Transform _bulletPosition;
    public override void Start()
    {
        CurrentState = State.GunnerIdle();
        CurrentState.EnterState();
    }

    public void Shoot()
    {
        ObjectPooler.Instant.GetPoolObject("Bullet", _bulletPosition.transform.position, Quaternion.identity);
    }

    public void SwitchToIdleState()
    {
        CurrentState = State.GunnerIdle();
        CurrentState.EnterState();
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
    }

    
    public override void GotHit()
    {
        CurrentState.ExitState();
        CurrentState = State.GunnerGotHit();
        CurrentState.EnterState();
    }
}
