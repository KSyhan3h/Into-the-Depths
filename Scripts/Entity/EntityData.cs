using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EntityData", menuName = "RPG Toolkit/Entity/Entity Data", order = 0)]
public class EntityData : ScriptableObject
{
    public string			name;
    public Stats			stats;
    public StatScaler		statScaler;
    // Story
	public List<SkillData>	skills;
    // Skills
    public Inventory		inventory;

	private void Awake ()
	{
		skills = new List<SkillData> ();
	}
}