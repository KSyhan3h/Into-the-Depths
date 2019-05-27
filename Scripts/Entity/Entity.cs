using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity
{
    public SpriteObject spriteObject;
    public EntityData   data;

    #region Constructor
    public Entity () { }

    public Entity (EntityData data) 
    {
        this.data = data;
        this.spriteObject = new SpriteObject (data.name);
    }
    #endregion
}
