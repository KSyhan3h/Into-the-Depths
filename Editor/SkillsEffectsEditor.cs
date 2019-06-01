using UnityEngine;
using UnityEditor;

public class SkillsEffectsEditor : EditorWindow
{ 
	#region STATICS
	private static Vector2 	WIN_MIN_SIZE = new Vector2Int (265, 300);
	private static string  	SKILLS_ASSET_PATH	= "Assets/Prefabs/Skills";
	private static string  	EFFECTS_ASSET_PATH	= "Assets/Prefabs/Effects";
	#endregion

	#region FIELDS
	private GUIWindow 		_currWindow;
	private SkillData 		skillsData;
	private EffectsData 	effectsData;
	#endregion

	#region TEMP FIELDS
	// Temporary Values
	#endregion

	[MenuItem ("RPG Toolkit Editors/Skills & Effects Editor")]
	public static SkillsEffectsEditor OpenSkillsEffectsDataEditor ()
	{
		SkillsEffectsEditor win = GetWindow<SkillsEffectsEditor> ("Skills & Effects Editor");
		win.minSize 			= WIN_MIN_SIZE;
		win.ResetTempValues ();
		return win;
	}

	[UnityEditor.Callbacks.OnOpenAsset (1)]
	public static bool OnOpenSkillsData (int instanceID, int line)
	{
		Object asset = EditorUtility.InstanceIDToObject (instanceID);

		if (asset != null)
		{
			SkillsEffectsEditor win = OpenSkillsEffectsDataEditor ();

			if (asset.GetType () == typeof (SkillData))
			{
				win._currWindow = GUIWindow.Skills;
			}
			else if (asset.GetType () == typeof (EffectsData))
			{
				win._currWindow = GUIWindow.Effects;
			}

			return true;
		}

		return false;
	}

	#region FUNCTIONS
	private void ResetTempValues ()
	{

	}
	#endregion

	#region GUI WINDOWS
	public enum GUIWindow
	{ 
		Skills,
		Effects
	}

	private void OnGUI ()
	{
		switch (_currWindow)
		{ 
			case GUIWindow.Skills:
				EditSkills ();
				ResetTempValues ();
				break;

			case GUIWindow.Effects:
				EditEffects ();
				ResetTempValues ();
				break;
		}
	}

	private void EditSkills () 
	{
		RenderWindowTab ();
		RenderOptionTab ();
	}

	private void EditEffects ()
	{
		RenderWindowTab ();

		if (GUILayout.Button ("Generate EffectsData Assets"))
		{
			GenerateEffectDatasAssets ();
		}

		RenderOptionTab ();
	}

	private void RenderWindowTab () 
	{
		EditorGUILayout.BeginHorizontal ();
		
		if (GUILayout.Button ("Skills"))
		{
			_currWindow = GUIWindow.Skills;
		}

		if (GUILayout.Button ("Effects"))
		{
			_currWindow = GUIWindow.Effects;
		}

		EditorGUILayout.EndHorizontal ();
	}

	private void RenderOptionTab ()
	{
		EditorGUILayout.BeginHorizontal ();
		EditorGUILayout.EndHorizontal ();
	}

	private void GenerateEffectDatasAssets ()
	{ 
		// Get all .cs files
		// Generate Scriptable Assets for these scripts
		// Put them unser the 
	}
	#endregion
}