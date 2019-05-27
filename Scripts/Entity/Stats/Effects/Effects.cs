using UnityEngine;

public abstract class Effects
{
    public string           description;
    public EffectsTarget    target;
    public EffectDuration   duration;

    public enum EffectsTarget 
    {
        Everyone,
        Self,
        Allies,
        Enemies
    }

    public enum EffectDuration
    {
        Actions,
        Turns,
        Combats,
        Missions,  
        Permanent
    }
}    