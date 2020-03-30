
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject _enemy;
    public float _spawnRate = 2.0f;

    private float _randomX, _nextSpawn = 0.0f;
    private Vector2 _whereToSpawn;
    private Camera _camera;

    private void Start()
    {
        _camera = GetComponent<Camera>();
    }

    private void Update()
    {
        if (Time.time > _nextSpawn)
        {
            _nextSpawn = Time.time + _spawnRate;
            _randomX = Random.Range(_camera.transform.position.x - 16, _camera.transform.position.x + 16);
            _whereToSpawn = new Vector2(_randomX, _camera.transform.position.y + 20);
            Instantiate(_enemy, _whereToSpawn, Quaternion.identity);
        }
    }
}
