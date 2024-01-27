using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameEnums 
{
    public enum EPlayerState
    { idle, walk, jump, hatAttack, footAttack }

    public enum EEnemiesState
    {idle, walk, attack, gothit}

    public enum EEvents
    {
        HatOnBeingThrew,
        HatOnBackToPlayer
    }

}
