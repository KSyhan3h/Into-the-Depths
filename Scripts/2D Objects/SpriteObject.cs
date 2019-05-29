using UnityEngine;
using UnityEngine.UI;

// Handles Animation and Appearance of Object
public class SpriteObject : MonoBehaviour
{
    public Image		image;     
	public Animation	s_animation;

	public static SpriteObject CreateInstance (string name = "New SpriteObject") 
	{
		SpriteObject so = new GameObject (name)	.AddComponent<SpriteObject> ();
		so.image		= so.gameObject			.AddComponent<Image>		();
		so.s_animation	= so.gameObject			.AddComponent<Animation>	();
		return so;
	}
}