using UnityEngine;

[CreateAssetMenu(fileName = "Dialogue", menuName = "RPG Toolkit/Story/Dialogue")]
public class Dialogue : ScriptableObject 
{
    public EntityData   speaker;
    public string[]     lines;    
}