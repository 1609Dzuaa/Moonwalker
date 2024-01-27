using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GunnerStateManager : EnemiesStateManager
{
    public override void GotHit()
    {

    }

    public override void Start()
    {
        CurrentState = State.GunnerIdle();
        CurrentState.EnterState();
    }

    public void Shoot()
    {
        ObjectPooler.Instant.GetPoolObject("Bullet", transform.position, Quaternion.identity);
    }

    public void SwitchToIdleState()
    {
        CurrentState = State.GunnerIdle();
        CurrentState.EnterState();
    }

    public override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
    }
}
