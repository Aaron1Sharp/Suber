using UnityEngine;
namespace CustomTilemap
{
    public interface ICell
    {
        void Refresh(Vector2Int _position, ITileMap _tileMap, GameObject gameObject);
    }
}