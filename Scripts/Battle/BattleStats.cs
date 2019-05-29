using System;
using System.Collections.Generic;

// Temporary Stats
public class BattleStats
{
    #region Combat Stats
    public Entity               unit; 

    public Stats                battleStats;
    public Stats                finalStats;
    
    public int                  hp;
    public int                  mp;
    public float                excessHPRegen;
    public float                excessMPRegen;
    #endregion

    #region Effects
    public List<EffectsData>        onActionEffects;
    public List<EffectsData>        onTurnEffects;
    public List<EffectsData>        onCombatEffects;
    
    public List<StatPadding>    statPaddings;

    public void OnActionsInvoked () { }

    public void OnTurnInvoked () { }

    public void OnCombatInvoked () { } 
    #endregion

    public BattleStats (Entity unit)
    {
        this.unit       = unit;
        onActionEffects = new List<EffectsData>     ();
        onTurnEffects   = new List<EffectsData>     ();
        onCombatEffects = new List<EffectsData>     ();
        statPaddings    = new List<StatPadding> ();

        // Set Events
        BattleManager.OnActions += OnActionsInvoked;
        BattleManager.OnTurn    += OnTurnInvoked;
        BattleManager.OnCombat  += OnCombatInvoked;
    }
}