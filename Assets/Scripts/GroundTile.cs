using UnityEngine;
namespace CustomTilemap
{
    [CreateAssetMenu(menuName = "GroundTile")]
    public class GroundTile : ScriptableObject, ICell
    {
        public Sprite[] _sprites;
        public void Refresh(Vector2Int _position, ITileMap _tileMap, GameObject gameObject)
        {
            SpriteRenderer _CreatedTile = gameObject.GetComponent<SpriteRenderer>();
            _CreatedTile.sprite = _sprites[new System.Random().Next(9, _sprites.Length)];
                 if (Exist(_position + Vector2Int.right, _tileMap)
                 &&  Exist(_position + Vector2Int.left,  _tileMap)
                 && !Exist(_position + Vector2Int.up,    _tileMap))
                    _CreatedTile.sprite = _sprites[0];         
            else if (Exist(_position + Vector2Int.right, _tileMap)
                 && !Exist(_position + Vector2Int.left,  _tileMap)
                 && !Exist(_position + Vector2Int.up,    _tileMap))
                     _CreatedTile.sprite = _sprites[1];
            else if(!Exist(_position + Vector2Int.right, _tileMap)
                 &&  Exist(_position + Vector2Int.left,  _tileMap)
                 && !Exist(_position + Vector2Int.up,    _tileMap))
                    _CreatedTile.sprite = _sprites[2];            
            else if(!Exist(_position + Vector2Int.right, _tileMap)
                &&   Exist(_position + Vector2Int.left,  _tileMap)
                &&   Exist(_position + Vector2Int.up,    _tileMap))
                    _CreatedTile.sprite = _sprites[3];
            else if(Exist(_position + Vector2Int.right, _tileMap)
                && !Exist(_position + Vector2Int.left,  _tileMap)
                &&  Exist(_position + Vector2Int.up,    _tileMap))
                    _CreatedTile.sprite = _sprites[4];
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
                  /*
                   * 
                   * if (Exist(_position + Vector2Int.right, _tileMap)
                    &&  Exist(_position + Vector2Int.left,  _tileMap)
                    && !Exist(_position + Vector2Int.down,  _tileMap))
                    {
                        _CreatedTile.sprite = Bottom;
                    }
               else if (Exist(_position + Vector2Int.right, _tileMap)
                    && !Exist(_position + Vector2Int.left,  _tileMap)
                    && !Exist(_position + Vector2Int.down,  _tileMap))
                    {
                        _CreatedTile.sprite = BottomLeft;
                    }
              else if (!Exist(_position + Vector2Int.right, _tileMap)
                   &&   Exist(_position + Vector2Int.left,  _tileMap)
                   &&  !Exist(_position + Vector2Int.down,  _tileMap))
                   {
                        _CreatedTile.sprite = BottomRight;
                   }
                   */
