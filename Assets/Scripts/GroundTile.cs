using UnityEngine;
namespace CustomTilemap
{
    [CreateAssetMenu(menuName ="GroundTile")]
    public class GroundTile : ScriptableObject, ICell
    {
        public Sprite Top, Left, Right, Bottom, TopLeft, TopRight, Other, BottomRight, BottomLeft;
        public void Refresh(Vector2Int _position, ITileMap _tileMap, GameObject gameObject)
        {
            SpriteRenderer renderer = gameObject.GetComponent<SpriteRenderer>();
            renderer.sprite = Other;

                     if(Exist(_position + Vector2Int.right, _tileMap)
                     && Exist(_position + Vector2Int.left,  _tileMap)
                     &&!Exist(_position + Vector2Int.up,    _tileMap))
                     { 
                        renderer.sprite = Top;
                     }
                else if(Exist(_position + Vector2Int.right, _tileMap)
                     &&!Exist(_position + Vector2Int.left,  _tileMap)
                     &&!Exist(_position + Vector2Int.up,    _tileMap))
                     {
                         renderer.sprite = TopLeft;
                     }
               else if(!Exist(_position + Vector2Int.right, _tileMap)
                    &&  Exist(_position + Vector2Int.left,  _tileMap)
                    && !Exist(_position + Vector2Int.up,    _tileMap))
                    {
                        renderer.sprite = TopRight;
                    }
        }
        public bool Exist(Vector2Int position, ITileMap tileMap)
        {
            if (position.x >= 0 && position.x < tileMap.Width) {
                ICell tile = tileMap.GetCell(position);
                return tile != null;
            }
            return false;
        }
    }
}