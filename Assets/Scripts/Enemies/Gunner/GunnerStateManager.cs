using System.Collections;
using System.Collections.Generic;
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
}
