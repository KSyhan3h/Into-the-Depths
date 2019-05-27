using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayableUnit
{
    public Stats baseStats;
    public Stats bonusStats;
    public Stats finalStats;
    
    public List<Actions> actions;

    public List<Skills> skills;

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
}
