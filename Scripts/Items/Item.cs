using System;
using UnityEngine;

public class Item
{   
    public SpriteObject     spriteObject;
    public ItemData         data;
    public int              quantity;

    public void AddQuantity (int quantity) 
    {
        this.quantity += quantity;
    }

    public void RemoveQuantity (int quantity)
    {
        this.quantity -= quantity;
    }

    #region Constructors
    public Item () { }

    public Item (ItemData data)
    {
        this.data = data;
        this.spriteObject = new SpriteObject (data.name);
    }
    #endregion
}