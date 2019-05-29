using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "ItemData", menuName = "RPG Toolkit/ItemData", order = 0)]
public abstract class ItemData : ScriptableObject
{
    public string		name;
    public string		description;
	public string		lore;
    // Lore

    public Sprite		sprite;

	public List<string> tags;
    public bool			stackable;
    public int			maxCapacity;
	// price
	// material

	// Effects

	// Appearance | Animation

	public enum ItemType
	{ 
		Quest,			// Cannot be discarded
		Armor,
	}

	public enum Rarity
    {
        Common,			// 65%
        Uncommon,		// 45%
        Rare,			// 25%
        Unique,			// 15%
        Mystique,		// 10%
        Legendary		// 5%
    }

    public enum Grade 
    {
        Worthless,      // 25% - 50%
        Low,            // 50% - 65%
        Standard,       // 65% - 80%
        High,           // 80% - 90%	
		GodHand			// 90% - 100%
    }

	private void Awake()
	{
		tags = new List<string> ();
	}
}