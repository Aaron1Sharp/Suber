using UnityEngine;
namespace CustomTilemap
{
    public class TilemapRender : MonoBehaviour
    {
        public void Render(ITileMap _tilemap)
        {
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }
            for (int x = 0; x < _tilemap.Width; x++)
            {
                for (int y = 0; y < _tilemap.Height; y++)
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
        public GameObject CreateEmpty(Vector2Int position)
        {
            GameObject result = new GameObject(position.ToString());
            var transform = result.GetComponent<Transform>();
            transform.parent = GetComponent<Transform>();
            transform.localPosition = new Vector3(position.x, position.y, 0);
            result.AddComponent<SpriteRenderer>();

            return result;
        }
    }
}
