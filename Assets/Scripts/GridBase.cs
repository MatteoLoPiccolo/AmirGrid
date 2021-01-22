using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GridBase : MonoBehaviour
{
    [SerializeField] protected Vector3 _startPosition = Vector3.zero;
    [SerializeField] protected Vector3 _tileSize = Vector3.one;
    [SerializeField] protected Texture2D _gridImage2D;

    protected Dictionary<Vector2Int, TileBase> grid = new Dictionary<Vector2Int, TileBase>();

    // Start is called before the first frame update
    void Start()
    {
        GenerateGrid();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void GenerateGrid()
    {
        for (int x = 0; x < _gridImage2D.width; x++)
        {
            for (int y = 0; y < _gridImage2D.height; y++)
            {
                Color pixel = _gridImage2D.GetPixel(x, y);
                TileBase tilePrefab = Tile(pixel);

                if (tilePrefab)
                {
                    //instantiate tile (child of transform)
                    TileBase tile = Instantiate(tilePrefab, transform);
                    tile.transform.position = _startPosition + new Vector3(x * _tileSize.x, 0, y * _tileSize.z);
                    tile.transform.rotation = Quaternion.identity;

                    //init tile and add to dictionary
                    Vector2Int positionInGrid = new Vector2Int(x, y);
                    tile.Init(pixel, positionInGrid);
                    grid.Add(positionInGrid, tile);
                }
                else
                {
                    //Debug.Log("No Tile for this color: " + pixel);
                }
            }
        }
    }

    protected abstract TileBase Tile(Color pixel);
}