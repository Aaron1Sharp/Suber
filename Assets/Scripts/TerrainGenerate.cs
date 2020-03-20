using UnityEngine;
using CustomTilemap;
using UnityEngine.SceneManagement;

public class TerrainGenerate : MonoBehaviour
{
    public int Width;
    public GroundTile Tile;
    public float YesNo;
    [SerializeField] private bool _isGenerateOnStart = false;
    Collider2D collider;
    public void Start()
    {
        collider = GetComponent<Collider2D>();
        collider.isTrigger = false;
        InvokeRepeating("GenerateAndRender", 5, 5);
        if (_isGenerateOnStart)
        {  
            GenerateAndRender();
        }
    }
    private void Update()
    {
        switch (collider.isTrigger)
        {
            case false:
                YesNo = 0;
                break;
            default:
                YesNo = 1;
                break;
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            collider.isTrigger = !collider.isTrigger;
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
   /* private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            SceneManager.LoadScene("Cuber");
        }
    }*/
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            SceneManager.LoadScene("Cuber");
        }
    }
}
