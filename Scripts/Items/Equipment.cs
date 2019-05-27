using UnityEngine;

[CreateAssetMenu(fileName = "Equipment", menuName = "RPG Toolkit/Items/Equipment", order = 0)]
public class Equipment : ItemData
{
    public ArmorPart armorPart;

    public enum ArmorPart
    {
        Head,
        Torso,
        Arms,
        Legs,
        Feet
    }
}