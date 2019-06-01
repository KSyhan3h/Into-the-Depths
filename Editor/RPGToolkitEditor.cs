using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

/// <summary>
/// All in one editor
/// </summary>

public class RPGToolkitEditor : EditorWindow
{
	#region STATIC PROPERTIES
	private static Vector2 WIN_MIN_SIZE = new Vector2Int (265, 300);
	#endregion

	#region STATIC FUNCTIONS
	[MenuItem("RPG Toolkit Editors/RPG Toolkit Editor")]
	public static RPGToolkitEditor OpenEntityEditor()
	{
		RPGToolkitEditor win = GetWindow<RPGToolkitEditor>("RPG Toolkit Editor");
		win.minSize = WIN_MIN_SIZE;
		return win;
	}
	#endregion

	#region GUI
	private void OnGUI()
	{
		
	}
	#endregion
}
