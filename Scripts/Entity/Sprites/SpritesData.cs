using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "SpritesData", menuName = "RPG Toolkit/Entity/Sprites Data", order = 0)]
public class SpritesData : ScriptableObject
{
	public Animation			animation;
	public List<SpriteImage>	sprites;
}