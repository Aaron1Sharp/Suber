using UnityEngine;
using CustomTilemap;

public class TerrainGenerate : MonoBehaviour
{
    public int Width;
    //public int _groundHeight;
    public GroundTile Tile;

    public void Start()
    {
        ITileMap _tilemap = Generate();
        GetComponent<TilemapRender>().Render(_tilemap);
    }

    public ITileMap Generate()
    {
        HeightMapBasedTilemap tilemap = new HeightMapBasedTilemap(Width, Tile);
        int _groundHeight = 3;
        for (int x = 0; x < Width; x++)
        {
            if (x % 2 != 0)
            {
                _groundHeight = 3;
                _groundHeight += Random.Range(-1, 2);
            }
            tilemap.SetHeight(x, _groundHeight);
        }
        return tilemap;
        
    }
}
