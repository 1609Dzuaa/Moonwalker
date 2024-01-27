using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesStateFactory : MonoBehaviour
{
    EnemiesStateManager _context;

    public EnemiesStateFactory(EnemiesStateManager currentContext)
    {
        _context = currentContext;
    }

    //Bomman
    public EnemiesBaseState BommanIdle()
    {
        return new BommanIdleState(_context, this);
    }
    public EnemiesBaseState BommanWalk()
    {
        return new BommanWalkState(_context, this);
    }
    public EnemiesBaseState BommanAttack()
    {
        return new BommanAttackState(_context, this);
    }
    public EnemiesBaseState BommanGotHit(){
        return new BommanGotHitState(_context, this);
    }

    //Stomber
    public EnemiesBaseState StomberIdle()
    {
        return new StomberIdleState(_context, this);
    }
    public EnemiesBaseState StomberWalk()
    {
        return new StomberWalkState(_context, this);
    }
    public EnemiesBaseState StomberRun()
    {
        return new StomberRunState(_context, this);
    }
    public EnemiesBaseState StomberAttack()
    {
        return new StomberAttackState(_context, this);
    }
    public EnemiesBaseState StomberGotHit()
    {
        return new StomberGotHitState(_context, this);
    }
    
    //Gunner
    public EnemiesBaseState GunnerIdle()
    {
        return new GunnerIdleState(_context, this);
    }
    public EnemiesBaseState GunnerWalk()
    {
        return new GunnerWalkState(_context, this);
    }
    public EnemiesBaseState GunnerAttack()
    {
        return new GunnerAttackState(_context, this);
    }
    public EnemiesBaseState GunnerGotHit()
    {
        return new GunnerGotHitState(_context, this);
    }
}
