using UnityEngine;

// Handles Animation and Appearance of Object
public class SpriteObject
{
    public GameObject       gameObject;
    public SpriteRenderer   renderer;       // Appearance
    // Animation

    public SpriteObject (string name = "")
    {
        gameObject  = new GameObject (name);
        renderer    = gameObject.AddComponent<SpriteRenderer> ();
    }
}