using UnityEngine;
namespace CustomTilemap
{
    public interface ICell
    {
        bool Exist(Vector2Int position, ITileMap tileMap);
        void Refresh(Vector2Int _position, ITileMap _tileMap, GameObject gameObject);
    }
}