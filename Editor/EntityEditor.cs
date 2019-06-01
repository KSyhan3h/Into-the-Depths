using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EntityEditor : EditorWindow
{
	#region STATICS
	private static Vector2 WIN_MIN_SIZE = new Vector2Int (265, 300);
	private static string  ASSET_PATH	= "Assets/Prefabs/Entity";
	#endregion

	private EntityData	_entityData;			// Main Referense
	private EntityData	t_entityData;			// Temp Holder
	private GUIWindow	_currWindow;

	private Vector2		t_scrollPos;
	private int			t_intSliderVal;
	private float		t_floatSliderVal;
	private string		t_string;
	private GUIWindow	t_sort;
	private SpriteImage	t_spriteImage;

	#region DEBUG VALUES
	private bool		_showDebug = true;
	private Vector2		t_vector2;
	#endregion

	#region STATIC FUNCTIONS
	[MenuItem ("RPG Toolkit Editors/Entity Editor")]
	public static EntityEditor OpenEntityEditor ()
	{
		EntityEditor win = GetWindow<EntityEditor> ("Entity Editor");
		win.minSize		 = WIN_MIN_SIZE;
		return win;
	}

	[UnityEditor.Callbacks.OnOpenAsset (1)]
	public static bool OnOpenEntityData (int instanceID, int line)
	{
		EntityData entityData = EditorUtility.InstanceIDToObject (instanceID) as EntityData;

		if (entityData != null)
		{
			EntityEditor editorWindow  = OpenEntityEditor ();
			editorWindow._entityData   = entityData;
			editorWindow._currWindow   = GUIWindow.Stats;
			editorWindow.ResetTempValues ();
			return true;
		}

		return false;
	}
	#endregion

	#region FUNCTIONS
	private void ResetTempValues () 
	{ 
		t_intSliderVal	 = 0;
		t_floatSliderVal = 0;
		t_scrollPos		 = Vector2.zero;
		t_string		 = string.Empty;
	}

	private void SaveChanges () 
	{
		RenameEntityAssets (_entityData.name);
	}

	/// <summary>
	/// Creates a new entity data with the name provided
	/// </summary>
	/// <param name="entityName"></param>
	private void CreateNewEntity (string entityName) 
	{
		string newName			= entityName.Replace (" ", string.Empty);
		string path				= string	.Format	 ("{0}/{1}", ASSET_PATH, newName);
		// Create New Folder
		AssetDatabase.CreateFolder (ASSET_PATH, newName);

		// Create Entity Data
		_entityData				= Utility.CreateAsset<EntityData> (path, newName)					as EntityData;
		_entityData.statScaler	= Utility.CreateAsset<StatScaler> (path, newName + "_StatScaler")	as StatScaler;
		_entityData.inventory	= Utility.CreateAsset<Inventory>  (path, newName + "_Inventory")	as Inventory;

		_entityData.name		= entityName;
		_currWindow				= GUIWindow.Stats;

		#region DEBUG
		if (!_showDebug)
		{ 
			return;
		}

		Debug.Log("Creating asset in " + path);
		#endregion
	}

	private void DeleteAsset () 
	{

	}

	private void ResetChanges () 
	{

	}

	private void RenameEntityAssets (string newName)
	{
		// Remove Whitespace from string
		newName = newName.Replace (" ", string.Empty);

		RenameAsset	(_entityData,			 newName);
		RenameAsset (_entityData.statScaler, newName + "_StatScaler");
		RenameAsset (_entityData.inventory,	 newName + "_Inventory");

		//MoveAssets ()

		#region DEBUG
		if (!_showDebug)
		{
			return;
		}

		Debug.Log("Changed Entity Asset name from "		+ _entityData.name				+ " to " + newName);
		Debug.Log("Changed StatScaler Asset name from " + _entityData.statScaler.name	+ " to " + newName + "_StatScaler");
		Debug.Log("Changed Inventory Asset name from "	+ _entityData.inventory.name	+ " to " + newName + "_Inventory");
		#endregion
	}

	private void RenameAssetFolder () 
	{
		//string path = "";
		//return path;
	}

	private void RenameAsset (Object asset, string newName)
	{
		if (asset == null)
		{ 
			return;
		}

		string assetPath = AssetDatabase.GetAssetPath (asset);
		AssetDatabase.RenameAsset (assetPath, newName);
	}

	private void MoveAssets (string targetPath, params Object[] assets) 
	{
		foreach (var asset in assets)
		{
			
		}
	}
	#endregion

	#region GUI WINDOWS
	private void OnGUI ()
	{
		_entityData = EditorGUILayout.ObjectField(_entityData, typeof(EntityData), true) as EntityData;

		if (_entityData == null && _currWindow != GUIWindow.Default)
		{
			_currWindow = GUIWindow.Default;
			ResetTempValues ();
		}

		switch (_currWindow)
		{
			case GUIWindow.Default:
				DefaultWindow ();
				break;

			case GUIWindow.Sprites:
				EditSprites ();
				break;

			case GUIWindow.Stats:
				EditStats ();
				break;

			case GUIWindow.StatsScaler:
				EditStatsScaler ();
				break;

			case GUIWindow.Skills:
				EditSkills ();
				break;

			case GUIWindow.Inventory:
				EditInventory ();
				break;
		}

		#region DEBUG
		//if (!_showDebug)
		//{
		//	return;
		//}

		//if (t_vector2 != this.position.size)
		//{
		//	t_vector2 = this.position.size;
		//	Debug.Log("Window Size: " + t_vector2);
		//}
		#endregion
	}

	public enum GUIWindow
	{ 
		Default,
		Sprites,
		Stats,
		StatsScaler,
		Skills,
		Inventory
	}

	private void DefaultWindow ()
	{
		if (_entityData != null)
		{ 
			_currWindow = GUIWindow.Stats;
			return;
		}

		EditorGUILayout.LabelField ("Please select an Entity Data to Start!");
		EditorGUILayout.LabelField ("- OR -");
		EditorGUILayout.LabelField ("Create a new Entity Data");

		EditorGUILayout.BeginHorizontal ();
		if (GUILayout.Button ("Create New Entity"))
		{
			CreateNewEntity (t_string);
			t_string = string.Empty;
		}

		t_string = EditorGUILayout.TextField (t_string);
		EditorGUILayout.EndHorizontal ();
	}

	private void EditSprites ()
	{ 
		RenderWindowTab ();
		_entityData.sprites		= EditorGUILayout.ObjectField ("Sprites Data", _entityData.sprites, 
																	typeof (SpritesData), false) as SpritesData;
		SpritesData spritesData = _entityData.sprites;

		if (spritesData == null)
		{ 
			// Offer to create spritesdata
		}
		else
		{ 
			spritesData.animation = EditorGUILayout.ObjectField ("Animation", spritesData.animation, 
																	typeof (Animation), false) as Animation;
			EditorGUILayout.BeginVertical ();
			// Show Sprite
			// Show SpriteName
			EditorGUILayout.EndVertical ();
			//--------------------
			EditorGUILayout.Space ();
			GUIFunctions.CreateImageGroup (ref t_spriteImage);
			if (GUILayout.Button ("Add new SpriteImage"))
			{ 
				spritesData.sprites.Add (t_spriteImage);
				t_spriteImage = new SpriteImage ();
			}
			//--------------------
			// Show Preview 
		}
		RenderOptionsTab ();
	}

	private void EditStats () 
	{
		RenderWindowTab ();
		GUIFunctions.CreateTextField (ref _entityData.name, "Name");
		EditorGUILayout.Space ();
		RenderStatsEditor (ref _entityData.stats);
		RenderOptionsTab ();
	}

	private void EditStatsScaler ()
	{
		RenderWindowTab ();

		_entityData.statScaler	= EditorGUILayout.ObjectField ("Stat Scaler", _entityData.statScaler, 
																typeof(StatScaler), false) as StatScaler;
		StatScaler statScaler	= _entityData.statScaler;

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
			GUIFunctions.CreateIntField  (ref statScaler.maxAllocation,		  "Max Attrib Point Alloc");
			GUIFunctions.CreateBoolField (ref statScaler.randomizedAllocation, "Random Allocation");
			EditorGUILayout.Space ();

			List<Stats> stats	= statScaler.stats;
			EditorGUILayout.LabelField ("Stat Scaler Size: " + stats.Count);
			t_intSliderVal		= EditorGUILayout.IntSlider ("Level to Edit", t_intSliderVal, 0, stats.Count - 1);
			EditorGUILayout.Space ();

			if (GUILayout.Button ("Create New Scaler Instance"))
			{ 
				stats.Add (new Stats());
				Debug.Log ("Created new stat scaler level");
			}

			if (GUILayout.Button ("Remove Current Scaler"))
			{ 
				stats.RemoveAt	(t_intSliderVal);
				Debug.Log		("Removed Current Stat Level");
			}

			EditorGUILayout.Space ();
			
			if (stats.Count > 0)
			{
				Stats tempStats			= stats[t_intSliderVal];
				RenderStatsEditor (ref tempStats);
				stats[t_intSliderVal]	= tempStats;
			}
		}

		RenderOptionsTab ();
	}

	/// <summary>
	/// Edit the skills list of the entity
	/// </summary>
	private void EditSkills ()
	{
		RenderWindowTab ();

		

		RenderOptionsTab ();
	}

	private void EditInventory ()
	{
		RenderWindowTab ();

		_entityData.inventory	= EditorGUILayout.ObjectField ("Inventory", _entityData.inventory, 
																typeof(Inventory), false) as Inventory;
		Inventory inventory		= _entityData.inventory;

		EditorGUILayout.Space ();

		if (inventory.items == null)
		{
			inventory.items = new List<Item> ();
		}

		EditorGUILayout.BeginHorizontal ();
		EditorGUILayout.LabelField ("Total Items: " + inventory.items.Count);
		// Quick Search Option
		t_string = EditorGUILayout.TextField (t_string);
		// Sorting Option
		t_sort = (GUIWindow) EditorGUILayout.EnumPopup (t_sort);
		// Tags
		EditorGUILayout.EndHorizontal ();

		EditorGUILayout.BeginVertical ();
		t_scrollPos				= EditorGUILayout.BeginScrollView (t_scrollPos);
		EditorGUILayout.EndScrollView ();
		EditorGUILayout.EndVertical   ();

		EditorGUILayout.Space ();
		EditorGUILayout.BeginHorizontal ();
		// Information about the Item
		EditorGUILayout.LabelField ("Selected Item");
		t_floatSliderVal		= EditorGUILayout.Slider (t_floatSliderVal, 0, 1);
		EditorGUILayout.EndHorizontal ();
		RenderOptionsTab ();
	}

	private void RenderStatsEditor (ref Stats stats) 
	{
		if (stats == null)
		{ 
			Debug.LogWarning ("The stats that you are passing is null.");
			return;
		}

		EditorGUILayout.Space ();
		EditorGUILayout.BeginVertical ();
		t_scrollPos = EditorGUILayout.BeginScrollView (t_scrollPos);

		if (_currWindow == GUIWindow.Stats)
		{ 
			GUIFunctions.CreateIntField	(ref stats.level		.value, "Level");
			GUIFunctions.CreateIntField	(ref stats.levelCap		.value, "LevelCap");
			GUIFunctions.CreateIntField	(ref stats.experience	.value, "Experience");
			EditorGUILayout.Space ();
		}
		
		GUIFunctions.CreateIntField		(ref stats.movement		.value, "Movement");
		GUIFunctions.CreateIntField		(ref stats.skillPoints	.value, "Skill Points");
		EditorGUILayout.Space ();
		GUIFunctions.CreateIntField		(ref stats.vitality		.value, "Vitality");
		GUIFunctions.CreateIntField		(ref stats.dexterity	.value, "Dexterity");
		GUIFunctions.CreateIntField		(ref stats.spirit		.value, "Spirit");
		EditorGUILayout.Space ();
		GUIFunctions.CreateIntField		(ref stats.hp			.value, "HP");
		GUIFunctions.CreateIntField		(ref stats.hpRegen		.value, "HP Regen");
		EditorGUILayout.Space ();
		GUIFunctions.CreateIntField		(ref stats.mp			.value, "MP");
		GUIFunctions.CreateIntField		(ref stats.mpRegen		.value, "MP Regen");
		EditorGUILayout.Space ();
		GUIFunctions.CreateIntField		(ref stats.damage		.value, "Damage");
		GUIFunctions.CreateIntField		(ref stats.defense		.value, "Defense");
		EditorGUILayout.Space ();
		GUIFunctions.CreateFloatField	(ref stats.critDamage	.value, "Crit Damage");
		GUIFunctions.CreateFloatField	(ref stats.critRate		.value, "Crit Rate");
		EditorGUILayout.Space ();
		GUIFunctions.CreateFloatField	(ref stats.magicDamage	.value, "Magic Damage");
		GUIFunctions.CreateFloatField	(ref stats.magicDefense .value, "Magic Defense");
		EditorGUILayout.Space ();
		GUIFunctions.CreateFloatField	(ref stats.accuracy		.value, "Accuracy");
		GUIFunctions.CreateFloatField	(ref stats.evasion		.value, "Evasion");

		EditorGUILayout.EndScrollView ();
		EditorGUILayout.EndVertical ();
		EditorGUILayout.Space ();
	}

	private void RenderWindowTab ()
	{ 
		EditorGUILayout.BeginHorizontal ();

		if (GUILayout.Button ("Sprites"))
		{ 
			_currWindow = GUIWindow.Sprites;
			ResetTempValues ();
		}

		if (GUILayout.Button ("Stats"))
		{
			_currWindow = GUIWindow.Stats;
			ResetTempValues ();
		}

		if (GUILayout.Button ("Stats Scaler"))
		{
			_currWindow = GUIWindow.StatsScaler;
			ResetTempValues ();
		}
		
		if (GUILayout.Button ("Skills"))
		{ 
			_currWindow = GUIWindow.Skills;
			ResetTempValues ();
		}

		if (GUILayout.Button ("Inventory"))
		{
			_currWindow = GUIWindow.Inventory;
			ResetTempValues ();
		}

		EditorGUILayout.EndHorizontal ();
		EditorGUILayout.Space ();
	}

	private void RenderOptionsTab () 
	{
		EditorGUILayout.BeginHorizontal ();

		if (GUILayout.Button ("Delete"))
		{
			DeleteAsset ();
		}

		if (GUILayout.Button ("Save Changes"))
		{
			SaveChanges ();
		}

		if (GUILayout.Button ("Reset Changes"))
		{
			ResetChanges ();
		}

		EditorGUILayout.EndHorizontal ();
	}
	#endregion
}
