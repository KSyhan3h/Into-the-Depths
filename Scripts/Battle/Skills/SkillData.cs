using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "Skill", menuName = "RPG Toolkit/Entity/Skills", order = 0)]
public class SkillData : ScriptableObject
{
	public string				name;
	public string				description;
	public List<EffectsData>	effects;        // Effects		- Damage, heal, stats etc.


	// Preparation	- How long to activate
	// Preparation Stoppable?
	// Cooldown		- How long to be able to use/initiate again

	private void Awake ()
	{
		effects = new List<EffectsData> ();
	}
}