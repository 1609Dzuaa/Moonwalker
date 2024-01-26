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
    
}
