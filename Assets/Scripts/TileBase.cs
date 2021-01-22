using UnityEngine;

public class TileBase : MonoBehaviour
{
    [SerializeField] protected Color _pixel;
    [SerializeField] protected Vector2Int _positionInGrid;

    public void Init(Color pixel, Vector2Int positionInGrid)
    {
        this._pixel = pixel;
        this._positionInGrid = positionInGrid;
    }
}