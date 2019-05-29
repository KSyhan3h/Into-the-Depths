using System;
using UnityEngine;

public class Item
{   
    public SpriteObject     spriteObject;
    public ItemData         data;
    public int              quantity;

	public void InvokeEffect () 
	{ 
		// Equip or Consume Item
	}

    #region Constructors
    public Item () { }

    public Item (ItemData data)
    {
        this.data			= data;
        this.spriteObject	= SpriteObject.CreateInstance (data.name);
    }
    #endregion
}