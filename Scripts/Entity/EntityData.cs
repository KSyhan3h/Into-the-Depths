using UnityEngine;

public class EntityData : ScriptableObject
{
    public string		name;
	// public Story
	public SpritesData	sprites;
    public Stats		stats;
    public StatScaler	statScaler;
	public Skills		skills;
    public Inventory	inventory;
	public Actions		actions;
}