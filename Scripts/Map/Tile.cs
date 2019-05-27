using System.Linq;
using UnityEngine;

[System.Serializable]
public class Tile
{
    public SpriteObject spriteObject;
    // Occupant

    public Tile         Left;
    public Tile         Right;
    public Tile         Top;
    public Tile         Bottom;
    public Tile         TopRight;
    public Tile         TopLeft;
    public Tile         BottomRight;
    public Tile         BottomLeft;

    public Tile[] NeighboringTiles
    {
        get 
        {
            return new Tile[]
            {
                Left,
                Right,
                Top,
                Bottom,
                TopRight,
                TopLeft,
                TopRight,
                BottomLeft,
                BottomRight
            };
        }
    }

    public bool Contains (Tile tile)
    {
        return (Find (tile) != null);
    }

    public Tile Find (Tile tile)
    {
        return NeighboringTiles.Single (x => x == tile);
    }
}