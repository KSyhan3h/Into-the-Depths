using UnityEngine;

[CreateAssetMenu(fileName = "Objective", menuName = "RPG Toolkit/Quests/Objective")]
public class Objective : ScriptableObject 
{
    public string description;
	public QuestStatus status;
}