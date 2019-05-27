using System;
using UnityEngine;

public class BattleManager
{
    public static Action OnActions;
    public static Action OnTurn;
    public static Action OnCombat;

    public void ResetEvents () 
    {
        OnActions   = null;
        OnTurn      = null;
        OnCombat    = null;
    }
}