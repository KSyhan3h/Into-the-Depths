using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "RPG Toolkit/Entity/Inventory", order = 0)]
public class Inventory : ScriptableObject
{
    public int			maxCapacity;
    public List<Item>	items;

	private void Awake()
	{
		items = new List<Item> ();
	}

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