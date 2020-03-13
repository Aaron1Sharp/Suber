using UnityEngine;
public class TerrainGenerate : MonoBehaviour
{
    public int _height, _width;
    public GameObject Cell;
    public Transform Zero;
    void Start() => Generate();
    void Generate()
    {
        int _groundHeight = 5;
        for (int x = 0; x < _width; x++)
        {
            if (x % 2 == 0)
            {
                _groundHeight += Random.Range(-1, 2);
            }
            for (int y = _groundHeight; y > 0; y--)
            {
                Instantiate(Cell, Zero).transform.localPosition = new Vector3(x, y, 0);
            }
        }
        
    }
}
