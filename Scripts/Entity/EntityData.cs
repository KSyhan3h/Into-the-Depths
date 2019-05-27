using UnityEngine;

[CreateAssetMenu(fileName = "EntityData", menuName = "RPG Toolkit/Entity/Entity Data", order = 0)]
public class EntityData : ScriptableObject
{
    public string       name;
    public Stats        stats;
    public StatScaler   statScaler;
    // Story
    // Skills
    public Inventory    inventory;
}