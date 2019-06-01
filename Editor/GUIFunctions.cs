using UnityEngine;
using UnityEditor;

public static class GUIFunctions
{
    public static void CreateTextField (ref string val, string label)
	{
		val = EditorGUILayout.TextField (label, val);
	}

	public static void CreateBoolField (ref bool val, string label)
	{
		val = EditorGUILayout.Toggle (label, val);
	}

	public static void CreateIntField (ref float val, string label)
	{
		val = EditorGUILayout.IntField (label, (int) val);
	}

	public static void CreateIntField (ref int val, string label)
	{ 
		val = EditorGUILayout.IntField (label, val);;
	}

	public static void CreateFloatField (ref float val, string label)
	{
		val = EditorGUILayout.FloatField (label, val);
	}

	public static void CreateImageGroup (ref SpriteImage val)
	{ 
		EditorGUILayout.BeginVertical ();
		val.sprite	= EditorGUILayout.ObjectField	(val.sprite, typeof(Sprite), false) as Sprite;
		val.name	= EditorGUILayout.TextField		(val.name);
		EditorGUILayout.EndVertical ();
	}
}