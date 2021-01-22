using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public struct TileStruct
{
    public TileBase prefab;
    public Color color;
}

public class GridGame : GridBase
{
    [SerializeField] float yScale = 5f;
    [SerializeField] float scaleXyPosition = 12.5f;

    [SerializeField] TileStruct[] tiles = default;
        

    protected override TileBase Tile(Color pixel)
    {
        foreach (var tile in tiles)
        {
            if (tile.color == pixel)
            {
                Debug.Log(pixel);
                return tile.prefab;
            }
        }

        return null;
    }
}