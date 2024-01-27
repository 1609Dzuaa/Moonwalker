using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
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
}
