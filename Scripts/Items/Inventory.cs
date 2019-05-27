using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Inventory", menuName = "RPG Toolkit/Entity/Inventory", order = 0)]
public class Inventory : ScriptableObject
{
    public List<Item> items;
    public int maxCapacity;

    public void AddItem (params Item[] _items) 
    {
        foreach (var item in _items)
        {
        }
    }

    public void RemoveItem (params Item[] _items) 
    {
        foreach (var item in _items)
        {
        }
    }
}