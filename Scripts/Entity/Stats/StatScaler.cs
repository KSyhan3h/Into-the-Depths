using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StatScaler", menuName = "RPG Toolkit/Create/Entity/StatScaler")]
public class StatScaler : ScriptableObject 
{
	public int			maxAllocation;
	public bool			randomizedAllocation;
    public List<Stats>	stats;
}