using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "Mission", menuName = "RPG Toolkit/Quests/Quest")]
public class Quest : ScriptableObject 
{
    public string		name;
	public string		description;
    public Objective[]	objectives;
	public QuestStatus	status;

    // Upon completion; Unlocks the following | story | items | events | places
}

public enum QuestStatus 
{
	Completed,
	InProgress,
	Failed
}