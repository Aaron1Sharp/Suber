using System.Linq;
using UnityEngine;
namespace CustomTilemap
{
    public class HeightMapBasedTilemap : ITileMap
    {
        public int Count => _heights.Sum();
        public int Width => _heights.Length;
        public int Height => _heights.Max();

        private int[] _heights;
        private ICell _cell;

        public HeightMapBasedTilemap(int wigth, ICell cell)
        {
            _heights = new int[wigth];
            _cell = cell;
        }

        public void SetHeight(int x, int value)
        {
            if (x >= 0 || x < _heights.Length)
            {
                _heights[x] = value;
            }
            else
            {
                throw new System.ArgumentOutOfRangeException("x");
            }
        }
        public ICell GetCell(Vector2Int _position)
        {
            if (_position.x < 0 && _position.x >= _heights.Length) throw new System.ArgumentOutOfRangeException("x");
            if (_position.y > _heights[_position.x])
            {
                return null;
            }
            else
            {
                return _cell; 
            }
        }
    }
}