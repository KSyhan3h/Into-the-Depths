using System;
using System.IO;
using UnityEditor;
using UnityEngine;

public static class Utility
{
	public static ScriptableObject CreateAsset<T> (string path, string name) where T : ScriptableObject
	{
		Debug.Log ("Requests to Create Asset [" + path + "]");

		if (string.IsNullOrEmpty (path))
		{ 
			throw new Exception ("Please provide the appropriate asset path");
		}

		T asset			= ScriptableObject.CreateInstance<T> ();
		string newPath	= Path.Combine (path, name + ".asset");
		AssetDatabase.CreateAsset (asset, newPath);

		return asset;
	}

	public static ScriptableObject CreateAsset<T> (string path, string name, bool singleInstanceOnly) where T : ScriptableObject
	{ 
		// Find any other instances of this type (T) in the project
		// If there is already an existing instance then return that instance instead
		return CreateAsset<T> (path, name);
	}
}
