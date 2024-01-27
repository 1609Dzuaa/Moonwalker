using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BommanStateManager : EnemiesStateManager
{
    public BommanStateManager()
    {
    }

    public override void Start()
    {
        CurrentState = State.BommanIdle();
        CurrentState.EnterState();
    }

    public override void GotHit()
    {
        CurrentState.ExitState();
        CurrentState = State.BommanGotHit();
        CurrentState.EnterState();
    }

    public void Attack()
    {
        ObjectPooler.Instant.GetPoolObject("Egg", transform.position, Quaternion.identity);
    }

    public override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
    }
}
