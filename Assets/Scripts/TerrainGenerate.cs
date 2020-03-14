using UnityEngine;
using CustomTilemap;

public class TerrainGenerate : MonoBehaviour
{
    public int Width;
    public GroundTile Tile;

    [SerializeField] private bool _isGenerateOnStart = false;
    public void Start()
    {
        if (_isGenerateOnStart)
        {  
            GenerateAndRender();
        }
    }

    public void GenerateAndRender()
    {
        ITileMap _tilemap = Generate();
        GetComponent<TilemapRender>().Render(_tilemap);
        GetComponent<PolygonCollider2D>().points = _tilemap.GetCloseMash();
    }

    public ITileMap Generate()
    {
        HeightMapBasedTilemap tilemap = new HeightMapBasedTilemap(Width, Tile);
        int _groundHeight = 3;
        for (int x = 0; x < Width; x++)
        {
            if (x % 2 == 0)
            {
                _groundHeight += Random.Range(-1, 2);
            }
            tilemap.SetHeight(x, _groundHeight);
        }
        return tilemap;
        
    }
}
