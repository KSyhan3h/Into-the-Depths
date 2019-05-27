using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EntityEditor : EditorWindow
{
	public EntityData _entityData;
	public GUIWindow  currWindow;

	[MenuItem ("RPG Toolkit Editors/Entity/Entity Editor")]
	public static EntityEditor OpenEntityEditor ()
	{
		return GetWindow<EntityEditor> ("Entity Editor");
	}

	[UnityEditor.Callbacks.OnOpenAsset (1)]
	public static bool OnOpenEntityData (int instanceID, int line)
	{
		EntityData entityData = EditorUtility.InstanceIDToObject (instanceID) as EntityData;

		if (entityData != null)
		{
			EntityEditor editorWindow = OpenEntityEditor ();
			editorWindow._entityData = entityData;
			editorWindow.currWindow  = GUIWindow.Stats;
			return true;
		}

		return false;
	}

	private void OnGUI ()
	{
		_entityData = EditorGUILayout.ObjectField (_entityData, typeof(EntityData), true) as EntityData;

		if (_entityData == null)
		{ 
			currWindow = GUIWindow.Default;
		}

		switch (currWindow)
		{
			case GUIWindow.Default:
				DefaultWindow ();
				break;

			case GUIWindow.Stats:
				EditStats ();
				break;

			case GUIWindow.StatsScaler:
				EditStatsScaler ();
				break;

			case GUIWindow.Inventory:
				EditInventory ();
				break;
		}
	}

	#region Create GUI
	private void CreateTextField (ref string val, string label)
	{
		val = EditorGUILayout.TextField (label, val);
	}

	private void CreateBoolField (ref bool val, string label)
	{
		val = EditorGUILayout.Toggle (label, val);
	}

	private void CreateIntField (ref float val, string label)
	{
		val = EditorGUILayout.IntField (label, (int) val);
	}

	private void CreateIntField (ref int val, string label)
	{ 
		val = EditorGUILayout.IntField (label, val);;
	}

	private void CreateFloatField (ref float val, string label)
	{
		val = EditorGUILayout.FloatField (label, val);
	}
	#endregion

	#region GUI Windows
	public enum GUIWindow
	{ 
		Default,
		Stats,
		StatsScaler,
		Inventory
	}

	private void DefaultWindow ()
	{
		if (_entityData != null)
		{ 
			currWindow = GUIWindow.Stats;
			return;
		}

		EditorGUILayout.LabelField ("Please select an Entity Data to Start!");
		EditorGUILayout.LabelField ("- OR -");
		EditorGUILayout.LabelField ("Create a new Entity Data");

		if (GUILayout.Button ("Create New Entity"))
		{
			Debug.Log ("Creating new entity!");
		}
	}

	private void EditStats () 
	{
		RenderTabGroup ();

		if (_entityData == null)
		{ 
			return;
		}

		CreateTextField (ref _entityData.name, "Name: ");
		EditorGUILayout.Space ();
		RenderStatsEditor (ref _entityData.stats);
		RenderOptionsTabGroup ();
	}

	int tempIndex;
	private void EditStatsScaler ()
	{
		RenderTabGroup ();

		if (_entityData == null)
		{ 
			return;
		}

		StatScaler statScaler = _entityData.statScaler;
		statScaler = EditorGUILayout.ObjectField (statScaler, typeof(StatScaler), true) as StatScaler;
		EditorGUILayout.Space ();

		
		if (statScaler == null)
		{ 
			if (GUILayout.Button ("Create Stats Scaler"))
			{ 
				// Create Stats Scaler for Entity
			}
		}
		else 
		{
			CreateIntField  (ref statScaler.maxAllocation,		  "Max Attrib Point Alloc: ");
			CreateBoolField (ref statScaler.randomizedAllocation, "Random Allocation");
			EditorGUILayout.Space ();

			List<Stats> stats = statScaler.stats;
			EditorGUILayout.LabelField ("Stat Scaler Size: " + stats.Count);
			tempIndex = EditorGUILayout.IntSlider ("Level to Edit: ", tempIndex, 0, stats.Count - 1);
			EditorGUILayout.Space ();

			if (GUILayout.Button ("Create New Scaler Instance"))
			{ 
				stats.Add (new Stats());
				Debug.Log ("Created new stat scaler level");
			}

			if (GUILayout.Button ("Remove Current Scaler"))
			{ 
				stats.RemoveAt (tempIndex);
				Debug.Log ("Removed Current Stat Level");
			}

			EditorGUILayout.Space ();

			if (stats.Count > 0)
			{ 
				Stats tempStats  = stats[tempIndex];
				RenderStatsEditor (ref tempStats);
				stats[tempIndex] = tempStats;
			}
		}

		RenderOptionsTabGroup ();
	}

	private void EditInventory ()
	{
		RenderTabGroup ();
		RenderOptionsTabGroup ();
	}

	private void RenderStatsEditor (ref Stats stats) 
	{
		if (currWindow == GUIWindow.Stats)
		{ 
			CreateIntField	 (ref stats.level		.value, "Level: ");
			CreateIntField	 (ref stats.levelCap	.value, "LevelCap: ");
			CreateIntField	 (ref stats.experience	.value, "Experience: ");
			EditorGUILayout.Space ();
		}
		
		CreateIntField	 (ref stats.movement	.value, "Movement: ");
		CreateIntField	 (ref stats.skillPoints	.value, "Skill Points: ");
		EditorGUILayout.Space ();
		CreateIntField	 (ref stats.vitality	.value, "Vitality: ");
		CreateIntField	 (ref stats.dexterity	.value, "Dexterity: ");
		CreateIntField	 (ref stats.spirit		.value, "Spirit: ");
		EditorGUILayout.Space ();
		CreateIntField	 (ref stats.hp			.value, "HP: ");
		CreateIntField	 (ref stats.hpRegen		.value, "HP Regen: ");
		EditorGUILayout.Space ();
		CreateIntField	 (ref stats.mp			.value, "MP: ");
		CreateIntField	 (ref stats.mpRegen		.value, "MP Regen: ");
		EditorGUILayout.Space ();
		CreateIntField	 (ref stats.damage		.value, "Damage: ");
		CreateIntField	 (ref stats.defense		.value, "Defense: ");
		EditorGUILayout.Space ();
		CreateFloatField (ref stats.critDamage	.value, "Crit Damage: ");
		CreateFloatField (ref stats.critRate	.value, "Crit Rate: ");
		EditorGUILayout.Space ();
		CreateFloatField (ref stats.magicDamage	.value, "Magic Damage: ");
		CreateFloatField (ref stats.magicDefense.value, "Magic Defense: ");
		EditorGUILayout.Space ();
		CreateFloatField (ref stats.accuracy	.value, "Accuracy: ");
		CreateFloatField (ref stats.evasion		.value, "Evasion: ");
	}

	private void RenderTabGroup ()
	{ 
		EditorGUILayout.BeginHorizontal ();

		if (GUILayout.Button ("Stats"))
		{
			currWindow = GUIWindow.Stats;
		}

		if (GUILayout.Button ("Stats Scaler"))
		{
			currWindow = GUIWindow.StatsScaler;
		}

		if (GUILayout.Button ("Inventory"))
		{
			currWindow = GUIWindow.Inventory;
		}

		EditorGUILayout.EndHorizontal ();
	}

	private void RenderOptionsTabGroup () 
	{
		EditorGUILayout.BeginHorizontal ();

		if (GUILayout.Button ("Delete"))
		{
			Debug.Log ("Delete Entity");
		}

		if (GUILayout.Button ("Save Changes"))
		{
			Debug.Log ("Changes have been saved");
		}

		if (GUILayout.Button ("Reset Changes"))
		{
			Debug.Log ("Changes have been Reset");
		}

		EditorGUILayout.EndHorizontal ();
	}
	#endregion
}
