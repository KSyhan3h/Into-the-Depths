using UnityEngine;

public abstract class BaseStats
{
    public float value;

    public virtual void Add (BaseStats newStats)
    {
        this.value += newStats.value;
    }

    public virtual void ModifyStat (BaseStats stat, float modifier)
    {
        this.value = stat.value * modifier;
    }
}