using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity
{
    public SpriteObject		spriteObject;
    public EntityData		data;

	public Stats			baseStats;
	public Stats			bonusStats;
	public Stats			finalStats;

	public List<Actions>	actions;
	public List<SkillData>	skills;

	#region Actions
	public void AddActions<T> (params Actions[] _actions)
	{

	}

	public void RemoveActions<T> (params Actions[] _actions)
	{

	}
	#endregion

	#region Skills
	public void AddSkills<T> (params Actions[] _skills)
	{

	}

	public void RemoveSkills<T> (params Actions[] _skills)
	{

	}
	#endregion

	#region CONSTRUCTOR
	public Entity () { }

    public Entity (EntityData data) 
    {
        this.data			= data;
        this.spriteObject	= SpriteObject.CreateInstance (data.name);
    }
    #endregion
}
