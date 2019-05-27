using UnityEngine;

public abstract class ItemData : ScriptableObject
{
    public string name;
    public string description;
    // Lore

    public Sprite sprite;

    public int maxCapacity;
    public bool stackable;
    // price

    // Effects

    // Appearance | Animation

    public enum Rarity
    {
        Common,
        Uncommon,
        Rare,
        Unique,
        Mystique,
        Legendary
    }

    public enum Grade 
    {
        Worthless,      // 25% - 50%
        Low,            // 50% - 75%
        Standard,       // 75% - 90%
        High,           // 90% - 100%
    }
    
}