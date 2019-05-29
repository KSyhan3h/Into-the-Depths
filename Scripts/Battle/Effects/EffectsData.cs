using UnityEngine;

public abstract class EffectsData : ScriptableObject
{
	public string			name;
    public string           description;
	public int				durationCount;
    public EffectsTarget    target;
    public EffectDuration   duration;
	public MonoBehaviour	script;

    public enum EffectsTarget 
    {
        Self,
		Party,
        Allies,
        Enemies,
		Everyone
	}

	public enum EffectDuration
    {
        Actions,
        Turns,
        Combats,
        Missions,  
        Permanent
    }

	public void Invoke () 
	{ 
	}
}    