using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StomberStateManager : EnemiesStateManager
{
    public override void Start()
    {
        CurrentState = State.StomberIdle();
        CurrentState.EnterState();
    }

    public override void GotHit()
    {

    }

}
