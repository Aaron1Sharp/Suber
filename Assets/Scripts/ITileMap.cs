using UnityEngine;
namespace CustomTilemap
{
    public interface ITileMap
    {
        int Count { get; }
        int Width { get; }
        int Height { get; }
        ICell GetCell(Vector2Int _position);
        Vector2[] GetCloseMash();
    }
}