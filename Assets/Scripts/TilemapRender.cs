using UnityEngine;
using System.Linq;
namespace CustomTilemap
{
    public class TilemapRender : MonoBehaviour
    {
        public void Render(ITileMap _tilemap)
        {
            Clear();
            for (int x = 0; x < _tilemap.Width; x++)
            {
                for (int y = 0; y <= _tilemap.Height; y++)
                {
                    var _cell = _tilemap.GetCell(new Vector2Int(x, y));
                    if (_cell != null)
                    {
                        GameObject _cellGo = CreateEmpty(new Vector2Int(x, y));
                        _cell.Refresh(new Vector2Int(x, y), _tilemap, _cellGo);
                    }
                }
            }
        }
        public void Clear()
        {
            foreach (Transform child in transform.OfType<Transform>().ToList())
            {
            #if UNITY_EDITOR 
                DestroyImmediate(child.gameObject);
            #else
                Destroy(child.gameObject);
            #endif
            }
        }
        public GameObject CreateEmpty(Vector2Int position)
        {
            GameObject result = new GameObject(position.ToString());
            Transform transform = result.GetComponent<Transform>();
            transform.parent = GetComponent<Transform>();
            transform.localPosition = new Vector3(position.x, position.y, 0);
            result.AddComponent<SpriteRenderer>();
            return result;
        }
    }
}
